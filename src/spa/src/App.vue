<template>
    <va-navbar color="primary" shape class="mb-2">
        <template #left>
            <va-navbar-item class="logo">LOGO</va-navbar-item>
        </template>
        <template #right>
            <va-navbar-item>Dashboard</va-navbar-item>
            <va-navbar-item>Reports</va-navbar-item>
            <va-navbar-item>Users</va-navbar-item>
            <va-navbar-item>
                <va-icon name="search"/>
            </va-navbar-item>
            <va-navbar-item>
                <va-icon name="account_circle"/>
            </va-navbar-item>
        </template>
    </va-navbar>
    <router-view id="content" />
</template>

<style scoped>
.logo {
  font-weight: 600;
  font-size: 1.5rem;
}
</style>