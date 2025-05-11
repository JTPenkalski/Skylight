<script setup lang="ts">
import type { CurrentAlert } from '~/clients/Skylight';

const props = defineProps<{
	code: string;
	rows?: number;
}>();

const { api } = useSkylight();
const { data } = await useAsyncData(`alerts/${props.code}`, () =>
	api.getCurrentAlertsByType({ code: props.code }),
);

const hasData: ComputedRef<boolean> = computed(
	() => !!data.value && data.value.currentAlerts.length > 0,
);
const alerts: ComputedRef<CurrentAlert[]> = computed(() => {
	if (data.value) {
		return data.value.currentAlerts.sort((x, y) => {
			return new Date(x.effective).getTime() - new Date(y.effective).getTime();
		});
	}

	return [];
});
const title: ComputedRef<string> = computed(() => {
	return data.value ? `${plural(data.value.alertName)}` : 'Alerts';
});
</script>

<template>
	<Card class="card">
    <template #title>
      <div>Alert List</div>
    </template>
		<template #subtitle>
			<div>
				<div>{{ title }}</div>
			</div>
    </template>
    <template #content>
			<DataView v-if="hasData" paginator data-key="headline" :value="alerts" :rows="props.rows ?? 2">
				<template #list="slotProps">
					<div class="list">
						<AlertListItem v-for="(item, index) in slotProps.items"
							:key="index"
							:item="item"
							:code="props.code"
							:name="data?.alertName"
							:first="index === 0" />
					</div>
				</template>
			</DataView>
			<NoAlerts v-else />
    </template>
  </Card>
</template>

<style scoped lang="scss">
.list {
	display: flex;
	flex-direction: column;
	padding: 0.5rem;
}
</style>