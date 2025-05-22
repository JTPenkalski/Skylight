<script setup lang="ts">
const props = defineProps<{
	code: string;
}>();

const { api } = useSkylight();
const { data } = await useAsyncData(`alert-count/${props.code}`, () => {
	return api.getCurrentAlertCountByType({ code: props.code });
});

const count: ComputedRef<number> = computed(() => data.value?.count ?? 0);
const type: ComputedRef<string> = computed(() => {
	if (data.value) {
		return plural(data.value.alertName);
	}

	return 'Alerts';
});
const severity: ComputedRef<string> = computed(() => {
	if (count.value <= 0) {
		return 'marginal';
	}

	if (count.value <= 4) {
		return 'slight';
	}

	if (count.value <= 10) {
		return 'enhanced';
	}

	if (count.value <= 16) {
		return 'moderate';
	}

	return 'high';
});
</script>

<template>
  <DashboardCard
    class="card"
    title="Current Alerts"
    :subtitle="type">
    <div :class="severity" class="
      border-2 font-semibold m-auto max-w-32 text-center
      p-2 md:p-4
      text-2xl md:text-4xl">
      {{ count }}
    </div>
  </DashboardCard>
</template>

<style scoped lang="css">
.marginal {
  background-color: var(--p-severity-marginal-background);
  border-color: var(--p-severity-marginal-color);
  border-radius: var(--p-card-border-radius);
}

.slight {
  background-color: var(--p-severity-slight-background);
  border-color: var(--p-severity-slight-color);
  border-radius: var(--p-card-border-radius);
}

.enhanced {
  background-color: var(--p-severity-enhanced-background);
  border-color: var(--p-severity-enhanced-color);
  border-radius: var(--p-card-border-radius);
}

.moderate {
  background-color: var(--p-severity-moderate-background);
  border-color: var(--p-severity-moderate-color);
  border-radius: var(--p-card-border-radius);
}

.high {
  background-color: var(--p-severity-high-background);
  border-color: var(--p--severityhigh-color);
  border-radius: var(--p-card-border-radius);
}
</style>
