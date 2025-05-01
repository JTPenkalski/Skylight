<template>
  <div class="content">
    <div class="row">
      <AlertCounter code="SVA" />
      <AlertCounter code="SVR" />
      <AlertCounter code="TOA" />
      <AlertCounter code="TOR" />
    </div>
    <div class="row">
      <AlertList code="SVR"/>
      <AlertList code="TOR"/>
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
