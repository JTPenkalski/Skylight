<script setup lang="ts">
import Card from 'primevue/card';
import { ref } from 'vue';

const props = defineProps<{
	count: number;
	label: string;
}>();

const count = ref(props.count);
const label = computed(() => {
	return pluralize(props.label, count);
});
const severity = computed(() => {
	if (props.count <= 0) {
		return 'marginal';
	}

	if (props.count <= 2) {
		return 'slight';
	}

	if (props.count <= 5) {
		return 'enhanced';
	}

	if (props.count <= 8) {
		return 'moderate';
	}

	return 'high';
});
</script>

<template>
  <Card class="card">
    <template #title>
      <div :class="severity" class="counter">{{ count }}</div>
    </template>
    <template #content>
      <div class="label">{{ label }}</div>
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
  border-width: 1px;
  font-size: 3rem;
  margin: auto;
  max-width: 9rem;
  padding: 1rem;
  text-align: center;
}

.label {
  font-size: 1.5rem;
  font-weight: 500;
  text-align: center;
}
</style>
