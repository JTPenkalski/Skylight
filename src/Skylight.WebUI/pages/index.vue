<script setup lang="ts">
import type { GetCurrentAlertsByTypeResponse } from '~/clients/Skylight';

// Get Axios
// Generate NSwag client using Axios
// Create composable useSkylight() to initialize with baseURL from runtime config
// const api = useSkylight();
// const result = await useAsyncData(() => api.getCurrentAlertsByType({ code: 'SVR' }));
// Then... figure out why SSR doesn't work???

const config = useRuntimeConfig();
const { data } = await useFetch<GetCurrentAlertsByTypeResponse>(
	`${config.public.apiBaseSkylight}/api/v1/Alerts/GetCurrentAlertsByType`,
	{
		method: 'POST',
		body: {
			code: 'SVR',
		},
	},
).then((x) => {
	console.log(x.data);
	return x;
});

const currentAlerts = computed(() => {
	return data.value?.currentAlerts;
});
</script>

<template>
  <div class="content">    
    <AlertCounter :count="currentAlerts?.length ?? 0" :label="currentAlerts?.at(0)?.alertName ?? ''" />
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
