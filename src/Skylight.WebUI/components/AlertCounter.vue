<script setup lang="ts">
const props = defineProps<{
	code: string;
}>();

const { api } = useSkylight();
const { data } = await useAsyncData(`alert-count/${props.code}`, () => {
	return api.getCurrentAlertCountByType({ code: props.code });
});

const count: ComputedRef<number> = computed(() => {
	return data.value?.count ?? 0;
});
const label: ComputedRef<string> = computed(() => {
	if (data.value) {
		return pluralize(data.value.alertName, count);
	}

	return 'Alerts';
});
const severity: ComputedRef<string> = computed(() => {
	if (count.value <= 0) {
		return 'marginal';
	}

	if (count.value <= 2) {
		return 'slight';
	}

	if (count.value <= 5) {
		return 'enhanced';
	}

	if (count.value <= 8) {
		return 'moderate';
	}

	return 'high';
});
</script>

<template>
  <Card class="card">
    <template #title>
      <span>{{ label }}</span>
    </template>
    <template #content>
      <div :class="severity" class="counter">{{ count }}</div>
    </template>
  </Card>
</template>

<style scoped lang="scss">
.card {
  flex: 1;
}

.marginal {
  background-color: var(--p-marginal-background);
  border-color: var(--p-marginal-color);
}

.slight {
  background-color: var(--p-slight-background);
  border-color: var(--p-slight-color);
}

.enhanced {
  background-color: var(--p-enhanced-background);
  border-color: var(--p-enhanced-color);
}

.moderate {
  background-color: var(--p-moderate-background);
  border-color: var(--p-moderate-color);
}

.high {
  background-color: var(--p-high-background);
  border-color: var(--p-high-color);
}

.counter {
  border-radius: var(--p-card-border-radius);
  border-style: solid;
  border-width: 2px;
  font-size: 2rem;
  font-weight: 500;
  margin: auto;
  max-width: 8rem;
  padding: 0.8rem;
  text-align: center;
}
</style>
