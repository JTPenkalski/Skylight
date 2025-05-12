<script setup lang="ts">
import { AlertParameterKey } from '~/clients/Skylight';
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
      <AlertTypeListCard code="TOA"/>
      <AlertTypeListCard code="TOW"/>
    </div>
    <div class="row">
      <AlertTypeListCard code="SVA"/>
      <AlertTypeListCard code="SVW"/>
    </div>
    <div class="row">
      <AlertTypeListCard code="FFA"/>
      <AlertTypeListCard code="FFW"/>
    </div>
    <div class="row">
      <AlertTypeListCard code="SPS"/>
      <AlertTypeListCard code="SVS"/>
    </div>
  </div>
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
