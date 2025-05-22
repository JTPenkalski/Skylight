<script setup lang="ts">
import type { CardPassThroughOptions } from 'primevue';

const props = defineProps<{
	title: string;
	subtitle?: string;
}>();

const pt: Ref<CardPassThroughOptions> = ref({
	caption: 'gap-0',
	body: 'h-full justify-between',
	content: 'my-auto',
});
</script>

<template>
	<Card :pt="pt">
		<template #title>
			<div class="flex flex-row">
				<span class="text-sm md:text-lg">{{ props.title }}</span>
			</div>
		</template>
		<template #subtitle>
			<div class="flex flex-row">
				<span v-if="props.subtitle" class="text-xs md:text-base">{{ props.subtitle }}</span>
			</div>
		</template>
		<template #content>
      <slot />
    </template>
	</Card>
</template>
