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
	return data.value?.sva.currentAlerts;
});
const currentSvs = computed(() => {
	return data.value?.svs.currentAlerts;
});
const currentToa = computed(() => {
	return data.value?.toa.currentAlerts;
});
const currentTor = computed(() => {
	return data.value?.tor.currentAlerts;
});
</script>

<template>
  <div class="content">
    <AlertCounter :count="currentSva?.length ?? 0" :label="currentSva?.at(0)?.alertName ?? 'Alert'" />
    <AlertCounter :count="currentSvs?.length ?? 0" :label="currentSvs?.at(0)?.alertName ?? 'Alert'" />
    <AlertCounter :count="currentToa?.length ?? 0" :label="currentToa?.at(0)?.alertName ?? 'Alert'" />
    <AlertCounter :count="currentTor?.length ?? 0" :label="currentTor?.at(0)?.alertName ?? 'Alert'" />
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
