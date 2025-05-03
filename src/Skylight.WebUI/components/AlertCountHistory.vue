<script setup lang="ts">
import 'chartjs-adapter-date-fns';
import { type ChartData, type ChartDataset, type ChartOptions } from 'chart.js';
import { subHours } from 'date-fns';

interface TimePoint {
	x: Date | string;
	y: number;
}

const props = defineProps<{
	codes: string[];
	title: string;
	hours?: number;
}>();

const now: Ref<Date> = ref(new Date());

const title = computed(() => `${props.title} Alert History`);
const hours = computed(() => props.hours ?? 6);

const textColor = useThemeColor('text.muted.color').color;
const gridColor = useThemeColor('content.border.color').color;

const { api } = useSkylight();
const { data } = await useAsyncData(`alert-count-history/${props.codes.join(',')}`, async () => {
	return await Promise.all(
		props.codes.map((x) =>
			api.getHourlyAlertCountsByType({
				code: x,
				start: now.value,
				pastHours: hours.value,
			}),
		),
	);
});

const datasets: ComputedRef<ChartDataset<'line', TimePoint[]>[]> = computed(() => {
	return (
		data.value?.map((x) => {
			return {
				label: plural(x.alertLevel.toString()),
				data: x.alertCounts.map((x) => {
					return {
						x: x.dateTime,
						y: x.count,
					};
				}),
				fill: false,
			};
		}) ?? []
	);
});
const chart: ComputedRef<ChartData<'line', TimePoint[]>> = computed(() => {
	return {
		datasets: datasets.value,
	};
});
const options: Ref<ChartOptions<'line'>> = ref({
	maintainAspectRatio: false,
	responsive: true,
	scales: {
		x: {
			type: 'time',
			min: subHours(now.value, hours.value).toString(),
			title: {
				display: true,
				text: 'Time',
			},
			ticks: {
				color: textColor,
			},
			time: {
				unit: 'hour',
			},
			grid: {
				color: gridColor,
			},
		},
		y: {
			min: 0,
			title: {
				display: true,
				text: 'Alerts',
			},
			ticks: {
				color: textColor,
				stepSize: 1,
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
      <div>{{ title }}</div>
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