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
  <div class="content">
    <div class="row">
      <AlertTypeCurrentCountCard code="SVA" />
      <AlertTypeCurrentCountCard code="SVW" />
      <AlertTypeCurrentCountCard code="TOA" />
      <AlertTypeCurrentCountCard code="TOW" />
    </div>
    <div class="row">
      <AlertTypeHistoricalCountChartCard :codes="['SPS']" title="Special Weather Statement" />
      <AlertTypeHistoricalCountChartCard :codes="['FFA', 'FFW']" title="Flash Flood" />
      <AlertTypeHistoricalCountChartCard :codes="['SVA', 'SVW']" title="Severe Thunderstorm" />
      <AlertTypeHistoricalCountChartCard :codes="['TOA', 'TOW']" title="Tornado" />
    </div>
    <div class="row">
      <AlertTypeObservationTypesChartCard code="SVW" />
      <AlertTypeObservationTypesChartCard code="TOW" />
      <AlertTypeParametersChartCard :parameter="AlertParameterKey.MaxHailSize" />
      <AlertTypeParametersChartCard :parameter="AlertParameterKey.MaxWindGust" />
    </div>
    <div class="row">
      <AlertTypeListCard code="SVW"/>
      <AlertTypeListCard code="TOW"/>
    </div>
    <div class="row">
      <AlertTypeListCard code="SVA"/>
      <AlertTypeListCard code="TOA"/>
    </div>
    <div class="row">
      <AlertLocationsTableCard />
    </div>
    <div class="row">
      <AlertTypeListCard code="FFW"/>
      <AlertTypeListCard code="SPS"/>
    </div>
  </div>
  <Toast />
</template>

<style scoped lang="scss">
.content {
  display: flex;
  flex-direction: column;
  gap: 2vmin;
}

.row {
  display: flex;
  flex-direction: row;
  gap: 2vmin;
  justify-content: space-between;
}

@media (max-width: 767px) {
  .content {
    display: flex;
    flex-direction: column;
    gap: 1vmin;
  }

  .row {
    display: flex;
    flex-direction: row;
    gap: 1vmin;
    justify-content: space-between;
  }
}
</style>
