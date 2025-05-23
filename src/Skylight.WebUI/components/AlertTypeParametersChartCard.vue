<script setup lang="ts">
import type { ChartData, ChartOptions } from 'chart.js';
import { AlertParameterKey } from '~/clients/skylight';
import type { SubtitleOption } from './DashboardCard.vue';

const props = defineProps<{
	parameter?: AlertParameterKey;
}>();

const parameterOptions: Ref<SubtitleOption<AlertParameterKey>[]> = ref([
	{ name: 'Hail Threat', code: AlertParameterKey.HailThreat },
	{ name: 'Max Hail Size', code: AlertParameterKey.MaxHailSize },
	{ name: 'Max Wind Gust', code: AlertParameterKey.MaxWindGust },
	{ name: 'Office ID', code: AlertParameterKey.OfficeId },
	{ name: 'Tornado Detection', code: AlertParameterKey.TornadoDetection },
	{ name: 'Waterspout Detection', code: AlertParameterKey.WaterspoutDetection },
	{ name: 'Wind Threat', code: AlertParameterKey.WindThreat },
]);
const parameter: Ref<SubtitleOption<AlertParameterKey>> = ref(
	parameterOptions.value.find((x) => x.code === props.parameter) ?? parameterOptions.value[0],
);

const { api } = useSkylight();
const { data, refresh } = await useAsyncData(`alert-parameter-values/${parameter.value.code}`, () =>
	api.getCurrentAlertParameterValuesByParameter({ parameterKey: parameter.value.code }),
);

const hasData: ComputedRef<boolean> = computed(
	() => !!data.value && data.value.parameterCounts.length > 0,
);

const chartColors: ChartColors = useChartColors();
const chartData: ComputedRef<ChartData<'doughnut'>> = computed(() => {
	return {
		labels: data.value?.parameterValues ?? [],
		datasets: [
			{
				data: data.value?.parameterCounts.map((x) => x.count) ?? [],
			},
		],
	};
});
const chartOptions: Ref<ChartOptions<'doughnut'>> = ref({
	backgroundColor: chartColors.backgroundColors,
	borderColor: chartColors.textColor,
	borderWidth: 1,
	maintainAspectRatio: false,
	responsive: true,
});
</script>

<template>
	 <DashboardCard
	 	v-model:subtitle-option="parameter"
	 	class="card-md md:card"
		title="Alert Parameter"
		:subtitle-options="parameterOptions"
		@subtitle-option-changed="refresh">
			<Chart v-if="hasData" class="chart" type="doughnut" :data="chartData" :options="chartOptions" />
			<NoAlerts v-else />
	 </DashboardCard>
</template>