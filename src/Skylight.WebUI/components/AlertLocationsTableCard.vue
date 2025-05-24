<script setup lang="ts">
import { FilterMatchMode, FilterOperator } from '@primevue/core/api';
import { format } from 'date-fns';
import type { DataTableFilterMeta, DataTableFilterMetaData } from 'primevue';
import { AlertThreat } from '~/clients/skylight';

type DataTableGlobalFilterMetaData = DataTableFilterMeta & { global: DataTableFilterMetaData };

const { api } = useSkylight();
const { data } = await useAsyncData('alert-locations-summary', () =>
	api.getCurrentAlertLocationSummaries({}),
);

const filters: Ref<DataTableGlobalFilterMetaData> = ref(defaultFilters());
const maxAlertOptions: Ref<string[]> = ref(['RadarIndicated', 'Observed', 'PDS', 'Emergency']);
const pageOptions: Ref<number[]> = ref([5, 10, 25, 50]);

const hasData: ComputedRef<boolean> = computed(
	() => !!data.value && data.value.locations.length > 0,
);

function defaultFilters(): DataTableGlobalFilterMetaData {
	return {
		global: { value: null, matchMode: FilterMatchMode.CONTAINS },
		code: {
			operator: FilterOperator.AND,
			constraints: [{ value: null, matchMode: FilterMatchMode.STARTS_WITH }],
		},
		name: {
			operator: FilterOperator.AND,
			constraints: [{ value: null, matchMode: FilterMatchMode.STARTS_WITH }],
		},
		effectiveTime: {
			operator: FilterOperator.AND,
			constraints: [{ value: null, matchMode: FilterMatchMode.DATE_IS }],
		},
		expirationTime: {
			operator: FilterOperator.AND,
			constraints: [{ value: null, matchMode: FilterMatchMode.DATE_IS }],
		},
		maxThreat: {
			operator: FilterOperator.OR,
			constraints: [{ value: null, matchMode: FilterMatchMode.EQUALS }],
		},
		totalAlerts: {
			operator: FilterOperator.AND,
			constraints: [{ value: null, matchMode: FilterMatchMode.GREATER_THAN_OR_EQUAL_TO }],
		},
		tornadoWarnings: {
			operator: FilterOperator.AND,
			constraints: [{ value: null, matchMode: FilterMatchMode.GREATER_THAN_OR_EQUAL_TO }],
		},
		severeThunderstormWarnings: {
			operator: FilterOperator.AND,
			constraints: [{ value: null, matchMode: FilterMatchMode.GREATER_THAN_OR_EQUAL_TO }],
		},
		flashFloodWarnings: {
			operator: FilterOperator.AND,
			constraints: [{ value: null, matchMode: FilterMatchMode.GREATER_THAN_OR_EQUAL_TO }],
		},
		specialWeatherStatements: {
			operator: FilterOperator.AND,
			constraints: [{ value: null, matchMode: FilterMatchMode.GREATER_THAN_OR_EQUAL_TO }],
		},
		maxHail: {
			operator: FilterOperator.AND,
			constraints: [{ value: null, matchMode: FilterMatchMode.GREATER_THAN_OR_EQUAL_TO }],
		},
		maxWind: {
			operator: FilterOperator.AND,
			constraints: [{ value: null, matchMode: FilterMatchMode.GREATER_THAN_OR_EQUAL_TO }],
		},
		tornadoes: {
			value: null,
			matchMode: FilterMatchMode.EQUALS,
		},
		senderName: {
			operator: FilterOperator.AND,
			constraints: [{ value: null, matchMode: FilterMatchMode.STARTS_WITH }],
		},
	};
}

function clearFilters(): void {
	filters.value = defaultFilters();
}

function getMaxThreatSeverity(maxThreat: AlertThreat): string {
	switch (maxThreat) {
		case AlertThreat.Emergency:
			return 'danger';
		case AlertThreat.PDS:
			return 'warn';
		case AlertThreat.Observed:
			return 'success';
		case AlertThreat.RadarIndicated:
			return 'info';
	}

	return 'secondary';
}

function getMaxThreatIcon(maxThreat: AlertThreat): string {
	switch (maxThreat) {
		case AlertThreat.Emergency:
			return 'pi pi-exclamation-triangle';
	}

	return '';
}
</script>

<template>
	<DashboardCard
		class="card-lg"
		title="Current Locations">
		<DataTable
			v-if="hasData"
			v-model:filters="filters"
			data-key="code"
			striped-rows
			paginator
			filter-display="menu"
			size="small"
			sort-field="code"
			:global-filter-fields="['code', 'name', 'effectiveTime', 'expirationTime', 'maxThreat']"
			:rows="10"
			:rows-per-page-options="pageOptions"
			:sort-order="1"
			:value="data?.locations">

			<template #header>
				<div class="flex flex-row gap-2">
					<IconField class="grow">
						<InputIcon>
							<i class="pi pi-search" />
						</InputIcon>
						<InputText
							v-model="filters.global.value"
							fluid
							id="location-search"
							placeholder="Search..." />
					</IconField>

					<Button
						outlined
						class="min-w-32"
						icon="pi pi-filter-slash"
						label="Clear All"
						type="button"
						severity="danger"
						@click="clearFilters()" />
				</div>
			</template>

			<Column
				sortable
				field="code"
				header="Code"
				style="min-width: 8rem">
				<template #body="{ data }">
					{{ data.code }}
				</template>
				<template #filter="{ filterModel }">
					<InputText
						v-model="filterModel.value"
						placeholder="Search By Code"
						type="text" />
				</template>
				<template #filterclear="{ filterCallback }">
					<Button
						icon="pi pi-times"
						severity="danger"
						type="button"
						@click="filterCallback()" />
				</template>
				<template #filterapply="{ filterCallback }">
					<Button
						icon="pi pi-check"
						severity="success"
						type="button"
						@click="filterCallback()" />
				</template>
			</Column>

			<Column
				sortable
				field="name"
				header="Name"
				style="min-width: 16rem">
				<template #body="{ data }">
					{{ data.name }}
				</template>
				<template #filter="{ filterModel }">
					<InputText
						v-model="filterModel.value"
						placeholder="Search By Name"
						type="text" />
				</template>
				<template #filterclear="{ filterCallback }">
					<Button
						icon="pi pi-times"
						severity="danger"
						type="button"
						@click="filterCallback()" />
				</template>
				<template #filterapply="{ filterCallback }">
					<Button
						icon="pi pi-check"
						severity="success"
						type="button"
						@click="filterCallback()" />
				</template>
			</Column>

			<Column
				sortable
				data-type="date"
				field="effectiveTime"
				header="Start Time"
				style="min-width: 12rem">
				<template #body="{ data }">
					{{ format(data.effectiveTime, 'Pp') }}
				</template>
				<!-- <template #filter="{ filterModel }">
					<DatePicker
						v-model="filterModel.value"
						show-button-bar
						show-icon
						show-time
						hour-format="12"
						dateFormat="mm/dd/yy"
						placeholder="MM/DD/YYYY HH:MM TT"/>
						<p>{{ typeof filterModel.value }}</p>
						<p>{{ filterModel.value instanceof String }}</p>
						<p>{{ JSON.stringify(filterModel.value) }}</p>
				</template>
				<template #filterclear="{ filterCallback }">
					<Button
						icon="pi pi-times"
						severity="danger"
						type="button"
						@click="filterCallback()" />
				</template>
				<template #filterapply="{ filterCallback }">
					<Button
						icon="pi pi-check"
						severity="success"
						type="button"
						@click="filterCallback()" />
				</template> -->
			</Column>

			<Column
				sortable
				data-type="date"
				field="expirationTime"
				header="Stop Time"
				style="min-width: 12rem">
				<template #body="{ data }">
					{{ format(data.expirationTime, 'Pp') }}
				</template>
				<!-- <template #filter="{ filterModel }">
					<DatePicker
						v-model="filterModel.value"
						show-button-bar
						show-icon
						show-time
						hour-format="12"
						dateFormat="mm/dd/yy"
						placeholder="MM/DD/YYYY HH:MM TT"/>
						<p>{{ typeof filterModel.value }}</p>
						<p>{{ filterModel.value instanceof String }}</p>
						<p>{{ JSON.stringify(filterModel.value) }}</p>
				</template>
				<template #filterclear="{ filterCallback }">
					<Button
						icon="pi pi-times"
						severity="danger"
						type="button"
						@click="filterCallback()" />
				</template>
				<template #filterapply="{ filterCallback }">
					<Button
						icon="pi pi-check"
						severity="success"
						type="button"
						@click="filterCallback()" />
				</template> -->
			</Column>

			<Column
				sortable
				field="maxThreat"
				header="Max Threat"
				style="min-width: 12rem"
				:filter-match-mode-options="[
					{
						label: 'Equals',
						value: FilterMatchMode.EQUALS
					},
					{
						label:'Not equals',
						value: FilterMatchMode.NOT_EQUALS
					}
				]">
				<template #body="{ data }">
					<Tag
						:icon="getMaxThreatIcon(data.maxThreat)"
						:severity="getMaxThreatSeverity(data.maxThreat)"
						:value="insertSpaces(data.maxThreat)" />
				</template>
				<template #filter="{ filterModel }">
					<Select
						v-model="filterModel.value"
						show-clear
						placeholder="Select Status"
						:options="maxAlertOptions">
						<template #value="slotProps">
							{{ insertSpaces(slotProps.value ?? slotProps.placeholder) }}
						</template>
						<template #option="slotProps">
							<Tag
								:icon="getMaxThreatIcon(slotProps.option)"
								:severity="getMaxThreatSeverity(slotProps.option)"
								:value="insertSpaces(slotProps.option)" />
						</template>
					</Select>
				</template>
				<template #filterclear="{ filterCallback }">
					<Button
						icon="pi pi-times"
						severity="danger"
						type="button"
						@click="filterCallback()" />
				</template>
				<template #filterapply="{ filterCallback }">
					<Button
						icon="pi pi-check"
						severity="success"
						type="button"
						@click="filterCallback()" />
				</template>
			</Column>

			<Column
				sortable
				data-type="numeric"
				field="totalAlerts"
				header="Total Alerts"
				style="min-width: 8rem">
				<template #body="{ data }">
					{{ data.totalAlerts }}
				</template>
				<template #filter="{ filterModel }">
					<InputNumber
						v-model="filterModel.value"
						:min="0"
						:max="100" />
				</template>
				<template #filterclear="{ filterCallback }">
					<Button
						icon="pi pi-times"
						severity="danger"
						type="button"
						@click="filterCallback()" />
				</template>
				<template #filterapply="{ filterCallback }">
					<Button
						icon="pi pi-check"
						severity="success"
						type="button"
						@click="filterCallback()" />
				</template>
			</Column>

			<Column
				sortable
				data-type="numeric"
				field="tornadoWarnings"
				header="TOR Alerts"
				style="min-width: 8rem">
				<template #body="{ data }">
					{{ data.tornadoWarnings }}
				</template>
				<template #filter="{ filterModel }">
					<InputNumber
						v-model="filterModel.value"
						:min="0"
						:max="100" />
				</template>
				<template #filterclear="{ filterCallback }">
					<Button
						icon="pi pi-times"
						severity="danger"
						type="button"
						@click="filterCallback()" />
				</template>
				<template #filterapply="{ filterCallback }">
					<Button
						icon="pi pi-check"
						severity="success"
						type="button"
						@click="filterCallback()" />
				</template>
			</Column>

			<Column
				sortable
				data-type="numeric"
				field="severeThunderstormWarnings"
				header="SVR Alerts"
				style="min-width: 8rem">
				<template #body="{ data }">
					{{ data.severeThunderstormWarnings }}
				</template>
				<template #filter="{ filterModel }">
					<InputNumber
						v-model="filterModel.value"
						:min="0"
						:max="100" />
				</template>
				<template #filterclear="{ filterCallback }">
					<Button
						icon="pi pi-times"
						severity="danger"
						type="button"
						@click="filterCallback()" />
				</template>
				<template #filterapply="{ filterCallback }">
					<Button
						icon="pi pi-check"
						severity="success"
						type="button"
						@click="filterCallback()" />
				</template>
			</Column>

			<Column
				sortable
				data-type="numeric"
				field="flashFloodWarnings"
				header="FFW Alerts"
				style="min-width: 8rem">
				<template #body="{ data }">
					{{ data.flashFloodWarnings }}
				</template>
				<template #filter="{ filterModel }">
					<InputNumber
						v-model="filterModel.value"
						:min="0"
						:max="100" />
				</template>
				<template #filterclear="{ filterCallback }">
					<Button
						icon="pi pi-times"
						severity="danger"
						type="button"
						@click="filterCallback()" />
				</template>
				<template #filterapply="{ filterCallback }">
					<Button
						icon="pi pi-check"
						severity="success"
						type="button"
						@click="filterCallback()" />
				</template>
			</Column>

			<Column
				sortable
				data-type="numeric"
				field="specialWeatherStatements"
				header="SPS Alerts"
				style="min-width: 8rem">
				<template #body="{ data }">
					{{ data.specialWeatherStatements }}
				</template>
				<template #filter="{ filterModel }">
					<InputNumber
						v-model="filterModel.value"
						:min="0"
						:max="100" />
				</template>
				<template #filterclear="{ filterCallback }">
					<Button
						icon="pi pi-times"
						severity="danger"
						type="button"
						@click="filterCallback()" />
				</template>
				<template #filterapply="{ filterCallback }">
					<Button
						icon="pi pi-check"
						severity="success"
						type="button"
						@click="filterCallback()" />
				</template>
			</Column>

			<Column
				sortable
				field="tornadoes"
				header="Tornadoes"
				style="min-width: 8rem"
				:max-constraints="0"
				:show-filter-match-modes="false"
				:show-filter-operator="false">
				<template #body="{ data }">
					<template v-if="data.tornadoes">
						<i class="pi pi-check" />
					</template>
				</template>
				<template #filter="{ filterModel }">
					<div>
						<Checkbox
						v-model="filterModel.value"
						binary
						inputId="filter-tornadoes"
						:indeterminate="filterModel.value === null" />

						<label for="filter-tornadoes"> Has Tornadoes</label>
					</div>
				</template>
				<template #filterclear="{ filterCallback }">
					<Button
						icon="pi pi-times"
						severity="danger"
						type="button"
						@click="filterCallback()" />
				</template>
				<template #filterapply="{ filterCallback }">
					<Button
						icon="pi pi-check"
						severity="success"
						type="button"
						@click="filterCallback()" />
				</template>
			</Column>

			<Column
				sortable
				data-type="numeric"
				field="maxHail"
				header="Max Hail Size"
				style="min-width: 12rem">
				<template #body="{ data }">
					{{ data.maxHail.toFixed(2) }}"
				</template>
				<template #filter="{ filterModel }">
					<InputNumber
						v-model="filterModel.value"
						:min="0"
						:max="10" />
				</template>
				<template #filterclear="{ filterCallback }">
					<Button
						icon="pi pi-times"
						severity="danger"
						type="button"
						@click="filterCallback()" />
				</template>
				<template #filterapply="{ filterCallback }">
					<Button
						icon="pi pi-check"
						severity="success"
						type="button"
						@click="filterCallback()" />
				</template>
			</Column>

			<Column
				sortable
				data-type="numeric"
				field="maxWind"
				header="Max Wind Speed"
				style="min-width: 14rem">
				<template #body="{ data }">
					{{ data.maxWind }} MPH
				</template>
				<template #filter="{ filterModel }">
					<InputNumber
						v-model="filterModel.value"
						:min="0"
						:max="100" />
				</template>
				<template #filterclear="{ filterCallback }">
					<Button
						icon="pi pi-times"
						severity="danger"
						type="button"
						@click="filterCallback()" />
				</template>
				<template #filterapply="{ filterCallback }">
					<Button
						icon="pi pi-check"
						severity="success"
						type="button"
						@click="filterCallback()" />
				</template>
			</Column>
			<template #empty>
				No locations found.
			</template>
		</DataTable>
		<NoAlerts v-else />
	</DashboardCard>
</template>
