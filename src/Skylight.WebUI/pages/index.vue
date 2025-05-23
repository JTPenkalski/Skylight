<script setup lang="ts">
import type { ToastServiceMethods } from 'primevue';
import { AlertParameterKey } from '~/clients/skylight';

const toast: ToastServiceMethods = useToast();

useAlertsHub({
	notifyNewAlerts: (input: NotifyNewAlertsInput) => {
		toast.add({
			severity: 'info',
			summary: 'New Alerts',
			detail: `${input.count} new ${pluralize('alert', input.count)} issued. Refresh this page to get the latest data.`,
			life: 5000,
		});
	},
	notifyExpiredAlerts: (input: NotifyNewAlertsInput) => {
		toast.add({
			severity: 'warn',
			summary: 'Expired Alerts',
			detail: `${input.count} ${pluralize('alert', input.count)} expired. Refresh this page to get the latest data.`,
			life: 10000,
		});
	},
});
</script>

<template>
  <div class="gap-2 grid grid-cols-2 lg:grid-cols-4">
    <AlertTypeCurrentCountCard code="SVA" />
    <AlertTypeCurrentCountCard code="TOA" />
    <AlertTypeCurrentCountCard code="SVW" />
    <AlertTypeCurrentCountCard code="TOW" />
    <AlertTypeHistoricalCountChartCard :codes="['SPS']" title="Special Weather Statement" />
    <AlertTypeHistoricalCountChartCard :codes="['FFA', 'FFW']" title="Flash Flood" />
    <AlertTypeHistoricalCountChartCard :codes="['SVA', 'SVW']" title="Severe Thunderstorm" />
    <AlertTypeHistoricalCountChartCard :codes="['TOA', 'TOW']" title="Tornado" />
    <AlertTypeObservationTypesChartCard code="SVW" />
    <AlertTypeObservationTypesChartCard code="TOW" />
    <AlertTypeParametersChartCard :parameter="AlertParameterKey.MaxHailSize" />
    <AlertTypeParametersChartCard :parameter="AlertParameterKey.MaxWindGust" />
    <AlertLocationsTableCard />
    <AlertTypeListCard code="SVW"/>
    <AlertTypeListCard code="TOW"/>
    <AlertTypeListCard code="SVA"/>
    <AlertTypeListCard code="TOA"/>
    <AlertTypeListCard code="FFW"/>
    <AlertTypeListCard code="SPS"/>
  </div>
  <Toast />
</template>
