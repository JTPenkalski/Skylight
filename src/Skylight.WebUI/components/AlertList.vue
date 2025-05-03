<script setup lang="ts">
import { format } from 'date-fns';

const props = defineProps<{
	code: string;
	rows?: number;
}>();

const { api } = useSkylight();
const { data } = await useAsyncData(`alerts/${props.code}`, () =>
	api.getCurrentAlertsByType({ code: props.code }),
);

const hasAlerts = computed(() => {
	return data.value && data.value.count > 0;
});
const alerts = computed(() => {
	if (data.value) {
		return data.value.currentAlerts.sort((x, y) => {
			return new Date(x.effective).getTime() - new Date(y.effective).getTime();
		});
	}

	return [];
});
const title = computed(() => {
	return data.value ? `${plural(data.value.alertName)} (${data.value.alertCode})` : 'Alerts';
});
const locations = computed(() => {
	return data.value?.currentAlerts.map((x) => x.locations.map((x) => x.name).join('; ')) ?? [];
});
</script>

<template>
	<Card class="card">
    <template #title>
      <div>{{ title }}</div>
    </template>
    <template #content>
			<DataView v-if="hasAlerts" paginator data-key="headline" :value="alerts" :rows="props.rows ?? 5">
				<template #list="slotProps">
					<div class="list">
						<div v-for="(item, index) in slotProps.items" :key="index" class="list-item" :class="{ 'list-divider': index !== 0 }">
							<div class="list-item-left">
								<span class="list-item-header">Alert</span>

								<div class="list-item-times">
									<Tag icon="pi pi-play-circle" severity="info" v-tooltip.top="'Effective Date'" :value="format(item.effective, 'PPpp')" />
									<Tag icon="pi pi-stop-circle" severity="info" v-tooltip.top="'Expiration Date'" :value="format(item.expires, 'PPpp')" />
								</div>

								<div class="list-item-tags">
									<Tag severity="secondary" :value="`Severity: ${item.severity}`" />
									<Tag severity="secondary" :value="`Urgency: ${item.urgency}`" />
									<Tag severity="secondary" :value="`Certainty: ${item.certainty}`" />
									<Tag severity="secondary" :value="`Response: ${item.response}`" />
								</div>

								<span class="list-item-locations"><b>Locations:</b> {{ locations[index] }}</span>
							</div>
							<div class="list-item-right">
								<div class="list-item-sender">
									<span>{{ item.senderName }}</span>
								<img alt="Sender Logo" class="sender-logo" src="assets/images/national-weather-service.png" />
								</div>
								<Button rounded aria-label="Details" class="list-item-expand" icon="pi pi-expand" severity="info" />
							</div>
						</div>
					</div>
				</template>
			</DataView>
			<span v-else>No current alerts.</span>
    </template>
  </Card>
</template>

<style scoped lang="scss">
.card {
  flex: 2;
}

.sender-logo {
	height: 3rem;
	width: 3rem;
}

.list {
	display: flex;
	flex-direction: column;
	padding: 0.5rem;
}

.list-divider {
	border-top: 1px solid;
	padding-top: 0.4rem;
	margin-top: 0.6rem;
}

.list-item {
	align-items: stretch;
	display: flex;
	flex-direction: row;
	justify-content: space-between;
	width: 100%;
}

.list-item-left {
	align-items: start;
	display: flex;
	flex-direction: column;
	gap: 0.2rem;
	max-width: 75%;
	text-align: left;
}

.list-item-right {
	align-items: end;
	display: flex;
	flex-direction: column;
	gap: 0.2rem;
	justify-content: space-between;
	text-align: right;
}

.list-item-header {
	font-size: 1.4rem;
	font-weight: 500;
	text-transform: uppercase;
}

.list-item-times {
	align-items: center;
	display: flex;
	flex-direction: row;
	gap: 0.2rem;
}

.list-item-tags {
	align-items: center;
	display: flex;
	flex-direction: row;
	flex-wrap: wrap;
	gap: 0.2rem;
}

.list-item-locations {
	align-items: center;
	display: flex;
	flex-direction: row;
	gap: 0.2rem;
	margin-top: 0.6rem;
}

.list-item-sender {
	align-items: end;
	display: flex;
	flex-direction: column;
	gap: 0.2rem;
}

.list-item-expand {
	margin-top: 0.6rem;
}
</style>