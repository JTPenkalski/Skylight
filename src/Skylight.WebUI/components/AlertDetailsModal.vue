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
			<div class="section">
				<span class="text-xl font-semibold">{{ data.headline }}</span>

				<span v-if="!!data.instruction">{{ data.instruction }}</span>

				<div class="flex flex-col md:flex-row gap-1 items-center">
					<Tag class="w-full md:w-auto text-center" icon="pi pi-send" severity="info" v-tooltip.top="'Sent Date'" :value="format(data.sent, 'Pp')" />
					<Tag class="w-full md:w-auto text-center" icon="pi pi-play-circle" severity="info" v-tooltip.top="'Effective Date'" :value="format(data.effective, 'Pp')" />
					<Tag class="w-full md:w-auto text-center" icon="pi pi-stop-circle" severity="info" v-tooltip.top="'Expiration Date'" :value="format(data.expires, 'Pp')" />
				</div>

				<div class="flex flex-col md:flex-row flex-wrap gap-1 items-center">
					<Tag class="w-full md:w-auto text-center" severity="secondary" :value="`Severity: ${data.severity}`" />
					<Tag class="w-full md:w-auto text-center" severity="secondary" :value="`Urgency: ${data.urgency}`" />
					<Tag class="w-full md:w-auto text-center" severity="secondary" :value="`Certainty: ${data.certainty}`" />
					<Tag class="w-full md:w-auto text-center mb-1 md:mb-0" severity="secondary" :value="`Response: ${data.response}`" />
					<Tag v-for="parameter in parameters" class="w-full md:w-auto text-center" severity="secondary" :value="parameter" />
				</div>

				<div class="flex flex-row gap-2 items-center">
					<img alt="Sender Logo" class="profile" src="assets/images/national-weather-service.png" />
					<span>{{ data.senderName }}</span>
				</div>
			</div>

			<div class="section">
				<Panel toggleable header="Description">
					<ScrollPanel class="w-full h-full">
						<span class="alert">{{ data.description }}</span>
					</ScrollPanel>
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
