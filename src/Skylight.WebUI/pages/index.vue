<template>
  <div class="content">
    <div class="row">
      <AlertTypeCurrentCountCard code="SVA" />
      <AlertTypeCurrentCountCard code="SVW" />
      <AlertTypeCurrentCountCard code="TOA" />
      <AlertTypeCurrentCountCard code="TOW" />
    </div>
    <div class="row">
      <AlertTypeHistoricalCountCard :codes="['SPS']" title="Special Weather Statement" />
      <AlertTypeHistoricalCountCard :codes="['FFA', 'FFW']" title="Flash Flood" />
      <AlertTypeHistoricalCountCard :codes="['SVA', 'SVW']" title="Severe Thunderstorm" />
      <AlertTypeHistoricalCountCard :codes="['TOA', 'TOW']" title="Tornado" />
    </div>
    <div class="row">
      <AlertTypeObservationTypesCard code="SVW" />
      <AlertTypeObservationTypesCard code="TOW" />
    </div>
    <div class="row">
      <AlertTypeCurrentListCard code="TOA"/>
      <AlertTypeCurrentListCard code="TOW"/>
    </div>
    <div class="row">
      <AlertTypeCurrentListCard code="SVA"/>
      <AlertTypeCurrentListCard code="SVW"/>
    </div>
    <div class="row">
      <AlertTypeCurrentListCard code="FFA"/>
      <AlertTypeCurrentListCard code="FFW"/>
    </div>
    <div class="row">
      <AlertTypeCurrentListCard code="SPS"/>
      <AlertTypeCurrentListCard code="SVS"/>
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
