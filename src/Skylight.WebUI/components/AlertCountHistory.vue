<script setup lang="ts">
import { type ChartData, type ChartDataset, type ChartOptions } from 'chart.js';
import currentDate from '~/utils/currentDate';

const props = defineProps<{
	codes: string[];
	hours?: number;
}>();

const { api } = useSkylight();
const { data } = await useAsyncData(`alert-count-history/${props.codes.join(',')}`, async () => {
	return await Promise.all(
		props.codes.map((x) =>
			api.getHourlyAlertCountsByType({
				code: x,
				start: currentDate(),
				pastHours: props.hours ?? 6,
			}),
		),
	);
});

const datasets: ComputedRef<ChartDataset<'line'>[]> = computed(() => {
	return (
		data.value?.map((x) => {
			return {
				label: pluralize(x.alertName, 2),
				data: x.alertCounts.map((x) => x.count),
				fill: false,
			};
		}) ?? []
	);
});

const textColor = useThemeColor('text.muted.color').color;
const gridColor = useThemeColor('content.border.color').color;

const chart: ComputedRef<ChartData<'line'>> = computed(() => {
	return {
		labels: pastHours(props.hours ?? 6),
		datasets: datasets.value,
	};
});

const options: Ref<ChartOptions<'line'>> = ref({
	maintainAspectRatio: false,
	responsive: true,
	scales: {
		x: {
			title: {
				display: true,
				text: 'Time',
			},
			ticks: {
				color: textColor,
			},
			grid: {
				color: gridColor,
			},
		},
		y: {
			title: {
				display: true,
				text: 'Alerts',
			},
			ticks: {
				color: textColor,
			},
			grid: {
				color: gridColor,
			},
		},
	},
});
</script>

<template>
	<Card class="card">
    <template #title>
      <div>Alert History</div>
    </template>
    <template #content>
      <Chart class="chart" type="line" :data="chart" :options="options" />
    </template>
  </Card>
</template>

<style scoped lang="scss">
.card {
  flex: 1;
	min-width: 0;
}

.chart {
	height: 12rem;
	position: relative;
}
</style>