<script setup lang="ts">
import { format } from 'date-fns';
import type { DynamicDialogInstance } from 'primevue/dynamicdialogoptions';
import { inject, onMounted } from 'vue';
import { AlertParameterKey, type CurrentAlert } from '~/clients/skylight';

const dialogRef = inject<Ref<DynamicDialogInstance>>('dialogRef');
const data: Ref<CurrentAlert | undefined> = ref();

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
		AlertParameterKey.EventSpeed,
		AlertParameterKey.EventDirection,
		AlertParameterKey.EventPosition,
		AlertParameterKey.EventTrackingNumber,
	];

	return (
		data.value?.parameters
			.filter((x) => visibleParameters.includes(x.key))
			.map((x) => `${insertSpaces(x.key)}: ${x.value}`) ?? []
	);
});

onMounted(() => {
	data.value = dialogRef?.value.data;
});
</script>

<template>
	<template v-if="!!data">
		<div class="flex flex-col gap-2 w-[70vw]">
			<div class="section flex flex-col gap-1 p-4 w-full">
				<span class="headline">{{ data.headline }}</span>

				<span v-if="!!data.instruction" class="instruction">{{ data.instruction }}</span>

				<div class="times">
					<Tag icon="pi pi-send" severity="info" v-tooltip.top="'Sent Date'" :value="format(data.sent, 'PPpp')" />
					<Tag icon="pi pi-play-circle" severity="info" v-tooltip.top="'Effective Date'" :value="format(data.effective, 'PPpp')" />
					<Tag icon="pi pi-stop-circle" severity="info" v-tooltip.top="'Expiration Date'" :value="format(data.expires, 'PPpp')" />
				</div>

				<div class="tags">
					<Tag severity="secondary" :value="`Severity: ${data.severity}`" />
					<Tag severity="secondary" :value="`Urgency: ${data.urgency}`" />
					<Tag severity="secondary" :value="`Certainty: ${data.certainty}`" />
					<Tag severity="secondary" :value="`Response: ${data.response}`" />
					<Tag v-for="parameter in parameters" severity="secondary" :value="parameter" />
				</div>

				<div class="sender">
					<img alt="Sender Logo" class="sender-logo" src="assets/images/national-weather-service.png" />
					<span>{{ data.senderName }}</span>
				</div>
			</div>

			<div class="section flex flex-col gap-1 p-4 w-full">
				<Panel toggleable header="Description">
					<span class="description">{{ data.description }}</span>
				</Panel>

				<Panel collapsed toggleable header="Locations">
					<DataTable size="small" sort-field="name" :sort-order="1" :value="data.locations">
						<Column sortable field="zone" header="Code" style="width: 25%"></Column>
						<Column sortable field="name" header="Name"></Column>
					</DataTable>
				</Panel>
			</div>
		</div>
	</template>
</template>

<style scoped lang="css">
.section {
	background-color: var(--p-form-field-background);
	border-radius: var(--p-card-border-radius);
}

.headline {
	font-size: 1.2rem;
	font-weight: 500;
	padding-bottom: 0.4rem;
}

.instruction {
	padding-bottom: 0.4rem;
}

.times {
	align-items: center;
	display: flex;
	flex-direction: row;
	gap: 0.2rem;
}

.tags {
	align-items: center;
	display: flex;
	flex-direction: row;
	flex-wrap: wrap;
	gap: 0.4rem;
}

.sender {
	align-items: center;
	display: flex;
	flex-direction: row;
	gap: 0.4rem;
	padding-top: 0.4rem;

	.sender-logo {
		height: 3rem;
		width: 3rem;
	}
}

.description {
	white-space: pre;
}
</style>