<script setup lang="ts">
const props = defineProps<{
	code: string;
}>();

const { api } = useSkylight();
const { data } = await useAsyncData(`alerts/${props.code}`, () =>
	api.getCurrentAlertsByType({ code: props.code }),
);

const pageOptions: Ref<number[]> = ref([3, 5, 10]);

const name: ComputedRef<string> = computed(() =>
	data.value ? `${plural(data.value.alertName)}` : 'Alerts',
);
const hasData: ComputedRef<boolean> = computed(
	() => !!data.value && data.value.currentAlerts.length > 0,
);
</script>

<template>
	<DashboardCard
		class="card-md"
		title="Alert List"
		:subtitle="name">
		<DataView
				v-if="hasData"
				paginator
				data-key="headline"
				:value="data?.currentAlerts"
				:rows="3"
				:rowsPerPageOptions="pageOptions">
				<template #list="slotProps">
					<div class="flex flex-col gap-2">
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
	</DashboardCard>
</template>
