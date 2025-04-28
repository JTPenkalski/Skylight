<script setup lang="ts">
import useSkylight from '~/composables/useSkylight';

const { api } = useSkylight();
const { data } = await useAsyncData(async () => {
	const [sva, svs, toa, tor] = await Promise.all([
		api.getCurrentAlertsByType({ code: 'SVA' }),
		api.getCurrentAlertsByType({ code: 'SVR' }),
		api.getCurrentAlertsByType({ code: 'TOA' }),
		api.getCurrentAlertsByType({ code: 'TOR' }),
	]);

	return { sva, svs, toa, tor };
});

const currentSva = computed(() => {
	return data.value?.sva;
});
const currentSvs = computed(() => {
	return data.value?.svs;
});
const currentToa = computed(() => {
	return data.value?.toa;
});
const currentTor = computed(() => {
	return data.value?.tor;
});
</script>

<template>
  <div class="content">
    <AlertCounter :count="currentSva?.count ?? 0" :label="currentSva?.alertName ?? 'Alert'" />
    <AlertCounter :count="currentSvs?.count ?? 0" :label="currentSvs?.alertName ?? 'Alert'" />
    <AlertCounter :count="currentToa?.count ?? 0" :label="currentToa?.alertName ?? 'Alert'" />
    <AlertCounter :count="currentTor?.count ?? 0" :label="currentTor?.alertName ?? 'Alert'" />
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
