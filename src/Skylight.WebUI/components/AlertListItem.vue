<script setup lang="ts">
import { format } from 'date-fns';
import { AlertParameterKey, type CurrentAlert } from '~/clients/Skylight';
import { AlertDetailsModal } from '#components';

const props = defineProps<{
	item: CurrentAlert;
	code: string;
	name?: string;
	first?: boolean;
}>();

const dialog = useDialog();

const header: ComputedRef<string> = computed(() => {
	const specialHeaderTypes = ['SVA', 'SVW', 'TOA', 'TOW'];

	if (specialHeaderTypes.includes(props.code)) {
		const detection = props.item.parameters.find(
			(x) => x.key.includes('Detection') || x.key.includes('DamageThreat'),
		);

		return detection?.value ?? 'Alert';
	}

	return 'Alert';
});
const locations: ComputedRef<string> = computed(() =>
	props.item.locations
		.slice(0, 5)
		.map((x) => x.name)
		.concat('...')
		.join('; '),
);
const parameters: ComputedRef<string[]> = computed(() => {
	const visibleParameters: AlertParameterKey[] = [
		AlertParameterKey.WindThreat,
		AlertParameterKey.MaxWindGust,
		AlertParameterKey.HailThreat,
		AlertParameterKey.MaxHailSize,
		AlertParameterKey.ThunderstormDamageThreat,
		AlertParameterKey.TornadoDamageThreat,
		AlertParameterKey.TornadoDetection,
		AlertParameterKey.WaterspoutDetection,
		AlertParameterKey.FlashFloodDamageThreat,
		AlertParameterKey.FlashFloodDetection,
		AlertParameterKey.SnowSquallDetection,
		AlertParameterKey.SnowSquallImpact,
	];

	return props.item.parameters
		.filter((x) => visibleParameters.includes(x.key))
		.map((x) => `${insertSpaces(x.key)}: ${x.value}`);
});

function onExpandAlert(alert: CurrentAlert) {
	dialog.open(AlertDetailsModal, {
		props: {
			draggable: false,
			header: props.name,
			maximizable: false,
			modal: true,
		},
		data: alert,
	});
}
</script>

<template>
	<div class="list-item" :class="{ 'list-divider': !props.first }">
		<div class="list-item-left">
			<span class="list-item-header">{{ header }}</span>

			<div class="list-item-times">
				<Tag icon="pi pi-play-circle" severity="info" v-tooltip.top="'Effective Date'" :value="format(item.effective, 'PPpp')" />
				<Tag icon="pi pi-stop-circle" severity="info" v-tooltip.top="'Expiration Date'" :value="format(item.expires, 'PPpp')" />
			</div>

			<div class="list-item-tags">
				<Tag severity="secondary" :value="`Severity: ${item.severity}`" />
				<Tag severity="secondary" :value="`Urgency: ${item.urgency}`" />
				<Tag severity="secondary" :value="`Certainty: ${item.certainty}`" />
				<Tag severity="secondary" :value="`Response: ${item.response}`" />
				<Tag v-for="(parameter, index) in parameters" severity="secondary" :key="index" :value="parameter" />
			</div>

			<span class="list-item-locations"><b>Locations:</b> {{ locations }}</span>
		</div>
		<div class="list-item-right">
			<div class="list-item-sender">
				<span>{{ item.senderName }}</span>
				<img alt="Sender Logo" class="sender-logo" src="assets/images/national-weather-service.png" />
			</div>
			<Button rounded aria-label="Details" class="list-item-expand" icon="pi pi-expand" severity="info" @click="onExpandAlert(item)" />
		</div>
	</div>
</template>

<style scoped lang="scss">
.sender-logo {
	height: 3rem;
	width: 3rem;
}

.list-divider {
	border-top: 1px solid;
	padding-top: 0.4rem;
	margin-top: 0.6rem;
}

.list-item {
	align-items: stretch;
	display: flex;
	flex-direction: row;
	justify-content: space-between;
	width: 100%;
}

.list-item-left {
	align-items: start;
	display: flex;
	flex-direction: column;
	gap: 0.2rem;
	max-width: 75%;
	text-align: left;
}

.list-item-right {
	align-items: end;
	display: flex;
	flex-direction: column;
	gap: 0.2rem;
	justify-content: space-between;
	text-align: right;
}

.list-item-header {
	font-size: 1.4rem;
	font-weight: 500;
	text-transform: uppercase;
}

.list-item-times {
	align-items: center;
	display: flex;
	flex-direction: row;
	gap: 0.2rem;
}

.list-item-tags {
	align-items: center;
	display: flex;
	flex-direction: row;
	flex-wrap: wrap;
	gap: 0.2rem;
}

.list-item-locations {
	align-items: center;
	display: flex;
	flex-direction: row;
	gap: 0.2rem;
	margin-top: 0.6rem;
}

.list-item-sender {
	align-items: end;
	display: flex;
	flex-direction: column;
	gap: 0.2rem;
}

.list-item-expand {
	margin-top: 0.6rem;
}
</style>