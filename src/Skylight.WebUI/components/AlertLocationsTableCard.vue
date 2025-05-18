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
		case AlertThreat.RadarIndicated:
			return 'info';
		case AlertThreat.Observed:
			return 'warn';
		case AlertThreat.PDS:
			return 'danger';
		case AlertThreat.Emergency:
			return 'danger';
	}

	return 'secondary';
}
</script>

<template>
	<Card class="card">
    <template #title>
      <span>Current Locations</span>
    </template>
    <template #content>
      <DataTable
				v-model:filters="filters"
				striped-rows
				paginator
				filter-display="menu"
				size="small"
				sort-field="code"
				:globalFilterFields="['code', 'name', 'effectiveDate', 'expirationDate', 'maxThreat']"
				:rows="10"
				:rowsPerPageOptions="pageOptions"
				:sort-order="1"
				:value="data?.locations">

				<template #header>
					<div class="table-header">
						<IconField class="table-search">
							<InputIcon>
								<i class="pi pi-search" />
							</InputIcon>
							<InputText fluid v-model="filters.global.value" placeholder="Keyword Search" />
						</IconField>

						<Button
							outlined
							icon="pi pi-filter-slash"
							label="Clear"
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
					<template #filter="{ filterModel, filterCallback }">
						<InputText
							v-model="filterModel.value"
							placeholder="Search By Code"
							type="text"
							@input="filterCallback()" />
					</template>
					<template #filterclear="{ filterCallback }">
						<Button
							v-tooltip.top="'Clear'"
							icon="pi pi-times"
							severity="danger"
							type="button"
							@click="filterCallback()" />
					</template>
					<template #filterapply="{ filterCallback }">
						<Button
							v-tooltip.top="'Apply'"
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
					<template #filter="{ filterModel, filterCallback }">
						<InputText
							v-model="filterModel.value"
							placeholder="Search By Name"
							type="text"
							@input="filterCallback()" />
					</template>
					<template #filterclear="{ filterCallback }">
						<Button
							v-tooltip.top="'Clear'"
							icon="pi pi-times"
							severity="danger"
							type="button"
							@click="filterCallback()" />
					</template>
					<template #filterapply="{ filterCallback }">
						<Button
							v-tooltip.top="'Apply'"
							icon="pi pi-check"
							severity="success"
							type="button"
							@click="filterCallback()" />
					</template>
				</Column>

				<Column
					sortable
					dataType="date"
					field="effectiveTime"
					header="Start Time"
					style="min-width: 12rem">
					<template #body="{ data }">
						{{ format(data.effectiveTime, 'yyyy/MM/dd hh:mm bb') }}
					</template>
					<template #filter="{ filterModel }">
						<DatePicker
							v-model="filterModel.value"
							dateFormat="yyyy/mm/dd"
							placeholder="yyyy/mm/dd" />
					</template>
					<template #filterclear="{ filterCallback }">
						<Button
							v-tooltip.top="'Clear'"
							icon="pi pi-times"
							severity="danger"
							type="button"
							@click="filterCallback()" />
					</template>
					<template #filterapply="{ filterCallback }">
						<Button
							v-tooltip.top="'Apply'"
							icon="pi pi-check"
							severity="success"
							type="button"
							@click="filterCallback()" />
					</template>
				</Column>

				<Column
					sortable
					dataType="date"
					field="expirationTime"
					header="Stop Time"
					style="min-width: 12rem">
					<template #body="{ data }">
						{{ format(data.expirationTime, 'yyyy/MM/dd hh:mm bb') }}
					</template>
					<template #filter="{ filterModel }">
						<DatePicker
							v-model="filterModel.value"
							dateFormat="yyyy/mm/dd"
							placeholder="yyyy/mm/dd" />
					</template>
					<template #filterclear="{ filterCallback }">
						<Button
							v-tooltip.top="'Clear'"
							icon="pi pi-times"
							severity="danger"
							type="button"
							@click="filterCallback()" />
					</template>
					<template #filterapply="{ filterCallback }">
						<Button
							v-tooltip.top="'Apply'"
							icon="pi pi-check"
							severity="success"
							type="button"
							@click="filterCallback()" />
					</template>
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
						<Tag :value="insertSpaces(data.maxThreat)" :severity="getMaxThreatSeverity(data.maxThreat)" />
					</template>
					<template #filter="{ filterModel, filterCallback }">
						<Select
							v-model="filterModel.value"
							showClear
							placeholder="Select Status"
							:options="maxAlertOptions"
							@change="filterCallback()">
							<template #option="slotProps">
								<Tag :value="insertSpaces(slotProps.option)" :severity="getMaxThreatSeverity(slotProps.option)" />
							</template>
						</Select>
					</template>
					<template #filterclear="{ filterCallback }">
						<Button
							v-tooltip.top="'Clear'"
							icon="pi pi-times"
							severity="danger"
							type="button"
							@click="filterCallback()" />
					</template>
					<template #filterapply="{ filterCallback }">
						<Button
							v-tooltip.top="'Apply'"
							icon="pi pi-check"
							severity="success"
							type="button"
							@click="filterCallback()" />
					</template>
				</Column>

				<Column
					sortable
					dataType="numeric"
					field="totalAlerts"
					header="Total Alerts"
					style="min-width: 8rem">
					<template #body="{ data }">
						{{ data.totalAlerts }}
					</template>
					<template #filter="{ filterModel, filterCallback }">
						<InputNumber
							v-model="filterModel.value"
							:min="0"
							:max="100"
							@input="filterCallback()" />
					</template>
					<template #filterclear="{ filterCallback }">
						<Button
							v-tooltip.top="'Clear'"
							icon="pi pi-times"
							severity="danger"
							type="button"
							@click="filterCallback()" />
					</template>
					<template #filterapply="{ filterCallback }">
						<Button
							v-tooltip.top="'Apply'"
							icon="pi pi-check"
							severity="success"
							type="button"
							@click="filterCallback()" />
					</template>
				</Column>

				<Column
					sortable
					dataType="numeric"
					field="tornadoWarnings"
					header="TOR Alerts"
					style="min-width: 8rem">
					<template #body="{ data }">
						{{ data.tornadoWarnings }}
					</template>
					<template #filter="{ filterModel, filterCallback }">
						<InputNumber
							v-model="filterModel.value"
							:min="0"
							:max="100"
							@input="filterCallback()" />
					</template>
					<template #filterclear="{ filterCallback }">
						<Button
							v-tooltip.top="'Clear'"
							icon="pi pi-times"
							severity="danger"
							type="button"
							@click="filterCallback()" />
					</template>
					<template #filterapply="{ filterCallback }">
						<Button
							v-tooltip.top="'Apply'"
							icon="pi pi-check"
							severity="success"
							type="button"
							@click="filterCallback()" />
					</template>
				</Column>

				<Column
					sortable
					dataType="numeric"
					field="severeThunderstormWarnings"
					header="SVR Alerts"
					style="min-width: 8rem">
					<template #body="{ data }">
						{{ data.severeThunderstormWarnings }}
					</template>
					<template #filter="{ filterModel, filterCallback }">
						<InputNumber
							v-model="filterModel.value"
							:min="0"
							:max="100"
							@input="filterCallback()" />
					</template>
					<template #filterclear="{ filterCallback }">
						<Button
							v-tooltip.top="'Clear'"
							icon="pi pi-times"
							severity="danger"
							type="button"
							@click="filterCallback()" />
					</template>
					<template #filterapply="{ filterCallback }">
						<Button
							v-tooltip.top="'Apply'"
							icon="pi pi-check"
							severity="success"
							type="button"
							@click="filterCallback()" />
					</template>
				</Column>

				<Column
					sortable
					dataType="numeric"
					field="flashFloodWarnings"
					header="FFW Alerts"
					style="min-width: 8rem">
					<template #body="{ data }">
						{{ data.flashFloodWarnings }}
					</template>
					<template #filter="{ filterModel, filterCallback }">
						<InputNumber
							v-model="filterModel.value"
							:min="0"
							:max="100"
							@input="filterCallback()" />
					</template>
					<template #filterclear="{ filterCallback }">
						<Button
							v-tooltip.top="'Clear'"
							icon="pi pi-times"
							severity="danger"
							type="button"
							@click="filterCallback()" />
					</template>
					<template #filterapply="{ filterCallback }">
						<Button
							v-tooltip.top="'Apply'"
							icon="pi pi-check"
							severity="success"
							type="button"
							@click="filterCallback()" />
					</template>
				</Column>

				<Column
					sortable
					dataType="numeric"
					field="specialWeatherStatements"
					header="SPS Alerts"
					style="min-width: 8rem">
					<template #body="{ data }">
						{{ data.specialWeatherStatements }}
					</template>
					<template #filter="{ filterModel, filterCallback }">
						<InputNumber
							v-model="filterModel.value"
							:min="0"
							:max="100"
							@input="filterCallback()" />
					</template>
					<template #filterclear="{ filterCallback }">
						<Button
							v-tooltip.top="'Clear'"
							icon="pi pi-times"
							severity="danger"
							type="button"
							@click="filterCallback()" />
					</template>
					<template #filterapply="{ filterCallback }">
						<Button
							v-tooltip.top="'Apply'"
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
					<template #filter="{ filterModel, filterCallback }">
						<div>
							<Checkbox
							v-model="filterModel.value"
							binary
							inputId="filter-tornadoes"
							:indeterminate="filterModel.value === null"
							@value-change="filterCallback()" />

							<label for="filter-tornadoes"> Has Tornadoes</label>
						</div>
					</template>
					<template #filterclear="{ filterCallback }">
						<Button
							v-tooltip.top="'Clear'"
							icon="pi pi-times"
							severity="danger"
							type="button"
							@click="filterCallback()" />
					</template>
					<template #filterapply="{ filterCallback }">
						<Button
							v-tooltip.top="'Apply'"
							icon="pi pi-check"
							severity="success"
							type="button"
							@click="filterCallback()" />
					</template>
				</Column>

				<Column
					sortable
					dataType="numeric"
					field="maxHail"
					header="Max Hail Size"
					style="min-width: 12rem">
					<template #body="{ data }">
						{{ data.maxHail.toFixed(2) }}"
					</template>
					<template #filter="{ filterModel, filterCallback }">
						<InputNumber
							v-model="filterModel.value"
							:min="0"
							:max="10"
							@input="filterCallback()" />
					</template>
					<template #filterclear="{ filterCallback }">
						<Button
							v-tooltip.top="'Clear'"
							icon="pi pi-times"
							severity="danger"
							type="button"
							@click="filterCallback()" />
					</template>
					<template #filterapply="{ filterCallback }">
						<Button
							v-tooltip.top="'Apply'"
							icon="pi pi-check"
							severity="success"
							type="button"
							@click="filterCallback()" />
					</template>
				</Column>

				<Column
					sortable
					dataType="numeric"
					field="maxWind"
					header="Max Wind Speed"
					style="min-width: 14rem">
					<template #body="{ data }">
						{{ data.maxWind }} MPH
					</template>
					<template #filter="{ filterModel, filterCallback }">
						<InputNumber
							v-model="filterModel.value"
							:min="0"
							:max="100"
							@input="filterCallback()" />
					</template>
					<template #filterclear="{ filterCallback }">
						<Button
							v-tooltip.top="'Clear'"
							icon="pi pi-times"
							severity="danger"
							type="button"
							@click="filterCallback()" />
					</template>
					<template #filterapply="{ filterCallback }">
						<Button
							v-tooltip.top="'Apply'"
							icon="pi pi-check"
							severity="success"
							type="button"
							@click="filterCallback()" />
					</template>
				</Column>
			</DataTable>
    </template>
  </Card>
</template>

<style scoped lang="scss">
.table-header {
	display: flex;
	flex-direction: row;
	justify-content: space-between;
}

.table-search {
	width: 50%;
}

.sender {
	align-items: center;
	display: flex;
	flex-direction: row;
	gap: 0.4rem;

	.sender-logo {
		height: 2rem;
		width: 2rem;
	}
}
</style>