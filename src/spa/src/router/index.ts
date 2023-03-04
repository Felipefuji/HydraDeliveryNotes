import { createRouter, createWebHashHistory, RouteRecordRaw } from 'vue-router'
import LoginView from "../views/LoginView.vue";

const routes: Array<RouteRecordRaw> = [
  {
    path: "/",
    name: "login",
    component: LoginView,
  },
  {
    path: "/register",
    name: "register",
    component: () => import(/* webpackChunkName: "about" */ "../views/RegisterView.vue"),
  },
  {
    path: "/dashboard",
    name: "dashboard",
    component: () => import(/* webpackChunkName: "about" */ "../views/DashboardView.vue"),
    meta: {
      authRequired: true,
    },
  },
  {
    path: '/about',
    name: 'about',
    component: () => import(/* webpackChunkName: "about" */ '../views/AboutView.vue')
  }
]

const router = createRouter({
  history: createWebHashHistory(),
  routes
})

router.beforeEach((to, from, next) => {
    const auth = localStorage.getItem('user');

    if (to.matched.some((record) => record.meta.authRequired)) {
        if (auth) {
            next();
        } else {
            alert("You've must been logged to access this area");
            router.push("/");
        }
    } else {
        next();
    }
});

export default router
