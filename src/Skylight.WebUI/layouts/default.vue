<template>
	<NavBar />
	<main>
		<slot />
	</main>
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
