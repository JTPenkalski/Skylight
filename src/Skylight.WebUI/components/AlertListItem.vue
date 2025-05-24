<script setup lang="ts">
import { format } from 'date-fns';
import { AlertParameterKey, type CurrentAlert } from '~/clients/skylight';
import { AlertDetailsModal } from '#components';

const props = defineProps<{
	item: CurrentAlert;
	code: string;
	name?: string;
	first?: boolean;
}>();

const dialog = useDialog();

const locations: ComputedRef<string> = computed(() =>
	props.item.locations
		.slice(0, 5)
		.map((x) => x.name)
		.concat('...')
		.join('; '),
);
const parameters: ComputedRef<string[]> = computed(() => {
	const visibleParameters: AlertParameterKey[] = [
		AlertParameterKey.MaxWindGust,
		AlertParameterKey.MaxHailSize,
		AlertParameterKey.TornadoDetection,
		AlertParameterKey.WaterspoutDetection,
		AlertParameterKey.EventTrackingNumber,
	];

	return props.item.parameters
		.filter((x) => visibleParameters.includes(x.key))
		.map((x) => `${insertSpaces(x.key)}: ${x.value}`);
});

function onExpandAlert(alert: CurrentAlert) {
	dialog.open(AlertDetailsModal, {
		props: {
			draggable: false,
			header: 'Alert Details',
			maximizable: false,
			modal: true,
		},
		data: alert,
	});
}
</script>

<template>
	<div class="flex flex-row justify-between py-2 w-full" :class="{ 'list-divider': !props.first }">
		<div class="flex flex-col gap-2 items-start max-w-[80%] text-left">
			<span class="text-lg md:text-2xl font-semibold uppercase">{{ props.item.observationType }}</span>

			<div class="flex flex-row items-center gap-1">
				<img alt="Sender Logo" class="profile-sm" src="assets/images/national-weather-service.png" />
				<span>{{ item.senderName }}</span>
			</div>

			<div class="flex flex-col md:flex-row gap-1">
				<Tag icon="pi pi-play-circle" severity="info" v-tooltip.top="'Effective Date'" :value="format(item.effective, 'Pp')" />
				<Tag icon="pi pi-stop-circle" severity="info" v-tooltip.top="'Expiration Date'" :value="format(item.expires, 'Pp')" />
			</div>

			<div class="flex flex-row flex-wrap gap-1">
				<Tag severity="secondary" :value="`Severity: ${item.severity}`" />
				<Tag severity="secondary" :value="`Urgency: ${item.urgency}`" />
				<Tag severity="secondary" :value="`Certainty: ${item.certainty}`" />
				<Tag severity="secondary" :value="`Response: ${item.response}`" />
				<Tag v-for="(parameter, index) in parameters" severity="secondary" :key="index" :value="parameter" />
			</div>

			<span><b>Locations:</b> {{ locations }}</span>
		</div>
		<div class="flex flex-col gap-1 items-end justify-between text-right">
			<Button rounded aria-label="Details" icon="pi pi-expand" severity="info" @click="onExpandAlert(item)" />
		</div>
	</div>
</template>

<style scoped lang="css">
.list-divider {
	border-top: 1px solid;
}
</style>