<script setup lang="ts">
import 'chartjs-adapter-date-fns';
import type { ChartData, ChartOptions } from 'chart.js';
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

const hourOptions: Ref<HourOption[]> = ref([
	{ name: '1 Hour', code: 1 },
	{ name: '3 Hours', code: 3 },
	{ name: '6 Hours', code: 6 },
	{ name: '12 Hours', code: 12 },
	{ name: '24 Hours', code: 24 },
]);
const hours: Ref<HourOption> = ref(hourOptions.value[1]);

const { api } = useSkylight();
const { data, refresh } = await useAsyncData(
	`alert-count-history/${props.codes.join(',')}`,
	async () => {
		return await Promise.all(
			props.codes.map((x) =>
				api.getHistoricalAlertCountsByType({
					code: x,
					start: new Date(),
					pastHours: hours.value.code,
				}),
			),
		);
	},
);

const chartColors: ChartColors = useChartColors();
const chartData: ComputedRef<ChartData<'line', TimePoint[]>> = computed(() => {
	return {
		datasets:
			data.value?.map((x, i) => {
				return {
					backgroundColor: chartColors.getBackgroundColor(i),
					borderColor: chartColors.getBorderColor(i),
					label: plural(x.alertLevel.toString()),
					data: x.alertCounts.map((x) => {
						return {
							x: x.dateTime,
							y: x.count,
						};
					}),
					fill: false,
				};
			}) ?? [],
	};
});
const chartOptions: Ref<ChartOptions<'line'>> = ref({
	maintainAspectRatio: false,
	responsive: true,
	tension: 0.1,
	scales: {
		x: {
			type: 'time',
			min: subHours(new Date(), hours.value.code).toString(),
			title: {
				display: true,
				text: 'Time',
			},
			ticks: {
				color: chartColors.textColor,
			},
			time: {
				unit: 'hour',
			},
			grid: {
				color: chartColors.gridColor,
			},
		},
		y: {
			min: 0,
			title: {
				display: true,
				text: 'Alerts',
			},
			ticks: {
				color: chartColors.textColor,
				stepSize: 1,
			},
			grid: {
				color: chartColors.gridColor,
			},
		},
	},
});
</script>

<template>
	<DashboardCard
		class="card-md md:card"
		title="Alert History"
		:subtitle="plural(props.title)">
		<div class="flex flex-col">
			<Chart class="chart" type="line" :data="chartData" :options="chartOptions" />
			<Select
				v-model="hours"
				fluid
				input-id="dd-hours"
				option-label="name"
				size="small"
				:options="hourOptions"
				@value-change="refresh" />
		</div>
	</DashboardCard>
</template>
