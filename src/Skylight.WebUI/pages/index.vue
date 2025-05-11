<template>
  <div class="content">
    <div class="row">
      <AlertCounter code="SVA" />
      <AlertCounter code="SVW" />
      <AlertCounter code="TOA" />
      <AlertCounter code="TOW" />
    </div>
    <div class="row">
      <AlertCountHistory :codes="['SPS']" title="Special Weather Statement" />
      <AlertCountHistory :codes="['FFA', 'FFW']" title="Flash Flood" />
      <AlertCountHistory :codes="['SVA', 'SVW']" title="Severe Thunderstorm" />
      <AlertCountHistory :codes="['TOA', 'TOW']" title="Tornado" />
    </div>
    <div class="row">
      <AlertTypeChart code="SVW" />
      <AlertTypeChart code="TOW" />
    </div>
    <div class="row">
      <AlertList code="TOA"/>
      <AlertList code="TOW"/>
    </div>
    <div class="row">
      <AlertList code="SVA"/>
      <AlertList code="SVW"/>
    </div>
    <div class="row">
      <AlertList code="FFA"/>
      <AlertList code="FFW"/>
    </div>
    <div class="row">
      <AlertList code="SPS"/>
      <AlertList code="SVS"/>
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
