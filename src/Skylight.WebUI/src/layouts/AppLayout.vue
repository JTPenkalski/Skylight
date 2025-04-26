<script setup>
import AppDashboard from './AppDashboard.vue';
import AppNavBar from './AppNavBar.vue';
</script>

<template>
  <div class="content">
    <AppNavBar />
    <main>
      <AppDashboard />
    </main>
  </div>
</template>

<style scoped lang="scss">
main {
  margin: calc(var(--navbar-height) + 2rem) 2rem;
}

@media (max-width: 767px) {
  main {
    margin: calc(var(--navbar-height) + 1rem) 1rem;
  }
}
</style>
