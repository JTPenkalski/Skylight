<script setup lang="ts">
const props = defineProps<{
	label: string;
}>();

const alerts = ref();
</script>

<template>
	<Card class="card">
    <template #title>
      <div>{{ props.label }}</div>
    </template>
    <template #content>
			<DataView :value="alerts" data-key="">
				<template #list>
					<div>Content</div>
				</template>
			</DataView>
    </template>
  </Card>
</template>

<style scoped lang="scss">
.card {
  flex: 2;
}
</style>