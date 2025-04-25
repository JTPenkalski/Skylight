<script setup lang="ts">
import { type Ref, ref } from 'vue';

type MenuItem = {
  name: string,
  icon: string,
  path: string,
};

type MenuSection = {
  label: string,
  items: MenuItem[],
};

const menu: Ref<MenuSection[]> = ref([
  {
    label: 'Home',
    items: [
      {
        name: 'Dashboard',
        icon: 'pi pi-home',
        path: '/'
      }
    ]
  }
]);
</script>

<template>
  <div class="sidebar">
    <ul class="sidebar-menu">
      <template v-for="section in menu" :key="section">
        <li class="sidebar-section-item">{{ section.label }}</li>
        <template v-for="item in section.items" :key="item">
          <li class="sidebar-menu-item">
            <a :href="item.path">
              <i class="sidebar-menu-item-icon" :class="item.icon"></i>
              <span class="sidebar-menu-item-text">{{ item.name }}</span>
            </a>
          </li>
        </template>
      </template>
    </ul>
  </div>
</template>

<style scoped lang="scss">
.sidebar {
  background-color: var(--p-overlay-popover-background);
  border-radius: var(--p-content-border-radius);
  bottom: 1rem;
  left: 1rem;
  overflow-y: auto;
  padding: 0.5rem 1.5rem;
  position: fixed;
  top: 4rem;
  transition:
    transform 0.2s,
    left 0.2s;
  width: 16rem;
  z-index: 999;

  .sidebar-menu {
    list-style-type: none;
    margin: 0;
    padding: 0;

    .sidebar-section-item {
      color: var(--p-text-color);
      font-size: 0.8rem;
      font-weight: 750;
      margin: 0.75rem 0;
      text-transform: uppercase;
    }

    .sidebar-menu-item {
      color: var(--p-text-color);
      font-size: 1rem;
      margin: 0.5rem 0;

      .sidebar-menu-item-icon {
        margin-right: 0.5rem;
      }

      a {
        align-items: center;
        border-radius: var(--p-content-border-radius);
        color: var(--p-text-color);
        display: flex;
        outline: 0 none;
        padding: 0.5rem 1rem;
        position: relative;
        text-decoration: none;
        transition:
          background-color var(--p-transition-duration);

        &:hover {
          background-color: var(--p-content-hover-background);
        }
      }
    }
  }
}

@media (max-width: 767px) {}
</style>
