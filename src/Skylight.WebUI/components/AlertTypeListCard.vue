<script setup lang="ts">
const props = defineProps<{
	code: string;
}>();

const { api } = useSkylight();
const { data } = await useAsyncData(`alerts/${props.code}`, () =>
	api.getCurrentAlertsByType({ code: props.code }),
);

const pageOptions: Ref<number[]> = ref([3, 5, 10]);

const title: ComputedRef<string> = computed(() =>
	data.value ? `${plural(data.value.alertName)}` : 'Alerts',
);
const hasData: ComputedRef<boolean> = computed(
	() => !!data.value && data.value.currentAlerts.length > 0,
);
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
			<DataView
				v-if="hasData"
				paginator
				data-key="headline"
				:value="data?.currentAlerts"
				:rows="3"
				:rowsPerPageOptions="pageOptions">
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