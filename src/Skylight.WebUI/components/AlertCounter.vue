<script setup lang="ts">
import Card from 'primevue/card';
import { ref } from 'vue';

const props = defineProps({
	count: { type: Number, required: true },
	label: { type: String, required: true },
});

const count = ref(props.count);
const label = computed(() => {
	return pluralize(props.label, count);
});
</script>

<template>
  <Card>
    <template #title>
      <div class="counter">{{ count }}</div>
    </template>
    <template #content>
      <div class="label">{{ label }}</div>
    </template>
  </Card>
</template>

<style scoped lang="scss">
.counter {
  background-color: var(--p-marginal-background);
  border-color: var(--p-marginal-color);
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
