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
      <AlertCountHistory :codes="['FFW']" title="Flash Flood" />
      <AlertCountHistory :codes="['SVA', 'SVW']" title="Severe Thunderstorm" />
      <AlertCountHistory :codes="['TOA', 'TOW']" title="Tornado" />
    </div>
    <div class="row">
      <AlertList code="SVW"/>
      <AlertList code="TOW"/>
    </div>
    <div class="row">
      <AlertList code="SPS"/>
      <AlertList code="FFW"/>
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
