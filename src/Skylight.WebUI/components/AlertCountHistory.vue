<script setup lang="ts">
import 'chartjs-adapter-date-fns';
import { type ChartData, type ChartDataset, type ChartOptions } from 'chart.js';
import { subHours } from 'date-fns';

interface TimePoint {
	x: Date | string;
	y: number;
}

interface HourOption {
	name: string;
	code: number;
}

const props = defineProps<{
	codes: string[];
	title: string;
}>();

const now: Ref<Date> = ref(new Date());

const hourOptions: Ref<HourOption[]> = ref([
	{ name: '1 Hour', code: 1 },
	{ name: '3 Hours', code: 3 },
	{ name: '6 Hours', code: 6 },
	{ name: '12 Hours', code: 12 },
	{ name: '24 Hours', code: 24 },
]);
const hours: Ref<HourOption> = ref(hourOptions.value[2]);

const textColor = useThemeColor('text.muted.color').color;
const gridColor = useThemeColor('content.border.color').color;

const { api } = useSkylight();
const { data, refresh } = await useAsyncData(
	`alert-count-history/${props.codes.join(',')}`,
	async () => {
		return await Promise.all(
			props.codes.map((x) =>
				api.getHourlyAlertCountsByType({
					code: x,
					start: now.value,
					pastHours: hours.value.code,
				}),
			),
		);
	},
);

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
			min: subHours(now.value, hours.value.code).toString(),
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
			<div class="title">
				<div>Alert History</div>
			</div>
    </template>
		<template #subtitle>
			<div class="title">
				<div>{{ plural(props.title) }}</div>
			</div>
    </template>
    <template #content>
      <Chart class="chart" type="line" :data="chart" :options="options" />
    </template>
		<template #footer>
      <div class="footer">
				<Select v-model="hours" inputId="dd-hours" optionLabel="name" size="small" :options="hourOptions" @value-change="refresh" />
			</div>
    </template>
  </Card>
</template>

<style scoped lang="scss">
.card {
  flex: 1;
	min-width: 0;
}

.title {
	align-items: center;
	display: flex;
	flex-direction: row;
}

.footer {
	align-items: center;
	display: flex;
	flex-direction: row;
	justify-content: end;
}

.chart {
	height: 12rem;
	position: relative;
}
</style>