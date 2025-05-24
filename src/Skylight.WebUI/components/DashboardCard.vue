<script setup lang="ts" generic="T">
import type { CardPassThroughOptions } from 'primevue';

export interface SubtitleOption<T> {
	name: string;
	code: T;
}

const props = defineProps<{
	title: string;
	subtitle?: string;
	subtitleOptions?: SubtitleOption<T>[];
}>();

const emit = defineEmits<{
	subtitleOptionChanged: [];
}>();

const subtitleOption = defineModel('subtitle-option');

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
				<Select v-else-if="props.subtitleOptions"
					v-model="subtitleOption"
					fluid
					option-label="name"
					size="small"
					:input-id="`dashboard-card-subtitle-option-${title}`"
					:options="subtitleOptions"
					@value-change="emit('subtitleOptionChanged')" />
			</div>
		</template>
		<template #content>
      <slot />
    </template>
	</Card>
</template>
