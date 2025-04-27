<template>
  <div class="content">
    <AlertCounter :count="3" label="Severe Thunderstorm Warning" />
    <AlertCounter :count="3" label="Severe Thunderstorm Warning" />
    <AlertCounter :count="3" label="Severe Thunderstorm Warning" />
    <AlertCounter :count="1" label="Severe Thunderstorm Warning" />
  </div>
</template>

<style scoped lang="scss">
.content {
  column-gap: 2vmin;
  display: grid;
  grid-template-columns: repeat(4, 1fr);
  row-gap: 2vmin;
}

@media (max-width: 767px) {
  .content {
    column-gap: 2vmin;
    display: grid;
    grid-template-columns: repeat(2, 1fr);
    row-gap: 2vmin;
  }
}
</style>
