import { computed, reactive } from 'vue';

type LayoutState = {
	isDarkTheme: boolean;
	isMenuActive: boolean;
	activeMenuItem: MenuItem | null;
};

type MenuItem = {
	name: string;
	path: string;
};

const layoutState: LayoutState = reactive({
	isDarkTheme: true,
	isMenuActive: true,
	activeMenuItem: null,
});

export function useLayout() {
	const setActiveMenuItem = (item) => {
		layoutState.activeMenuItem = item.value || item;
	};

	const toggleDarkMode = () => {
		// Transition immediately if the View Transition API is unavailable
		if (!document.startViewTransition) {
			executeDarkModeToggle();

			return;
		}

		document.startViewTransition(() => executeDarkModeToggle());
	};

	const executeDarkModeToggle = () => {
		layoutState.isDarkTheme = !layoutState.isDarkTheme;
		document.documentElement.classList.toggle('app-dark');
	};

	const toggleMenu = () => {
		layoutState.isMenuActive = !layoutState.isMenuActive;
	};

	const isDarkTheme = computed(() => layoutState.isDarkTheme);
	const isMenuActive = computed(() => layoutState.isMenuActive);

	return {
		isDarkTheme,
		toggleDarkMode,
		isMenuActive,
		toggleMenu,
		setActiveMenuItem,
	};
}
