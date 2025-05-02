<script setup lang="ts">
import type { ChartData, ChartOptions } from 'chart.js';

const props = defineProps<{
	codes: string[];
	hours?: number;
}>();

const textColor = useThemeColor('text.muted.color').color;
const gridColor = useThemeColor('content.border.color').color;

const chart: Ref<ChartData<'line'>> = ref({
	labels: pastHours(props.hours ?? 6),
	datasets: [
		{
			label: 'Watches',
			data: [65, 59, 80, 81, 56, 55, 40],
			fill: false,
			tension: 0.4,
		},
		{
			label: 'Warnings',
			data: [28, 48, 40, 19, 86, 27, 90],
			fill: false,
			tension: 0.4,
		},
	],
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