<script setup lang="ts">
import type { ChartData, ChartOptions } from 'chart.js';

const props = defineProps<{
	code: string;
}>();

const { api } = useSkylight();
const { data } = await useAsyncData(`alert-observation-types/${props.code}`, () =>
	api.getCurrentAlertObservationTypesByType({ code: props.code }),
);

const title: ComputedRef<string> = computed(() =>
	data.value ? `${plural(data.value.alertName)}` : 'Alert',
);
const hasData: ComputedRef<boolean> = computed(
	() => !!data.value && data.value.observationTypeCounts.length > 0,
);

const chartColors: ChartColors = useChartColors();
const chartData: ComputedRef<ChartData<'doughnut'>> = computed(() => {
	return {
		labels: data.value?.observationTypes ?? [],
		datasets: [
			{
				data: data.value?.observationTypeCounts.map((x) => x.count) ?? [],
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
	<Card class="card">
    <template #title>
			<div>Alert Types</div>
    </template>
		<template #subtitle>
			<div>{{ title }}</div>
    </template>
    <template #content>
      <Chart v-if="hasData" class="chart" type="doughnut" :data="chartData" :options="chartOptions" />
			<NoAlerts v-else />
    </template>
  </Card>
</template>
