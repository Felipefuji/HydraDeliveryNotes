import { createApp } from 'vue'
import App from './App.vue'
import router from './router'
import { createVuestic, createIconsConfig  } from "vuestic-ui";
import "vuestic-ui/styles/essential.css";
import "vuestic-ui/styles/typography.css";
import "vuestic-ui/styles/smart-helpers.css";
import "material-design-icons-iconfont/dist/material-design-icons.min.css";

createApp(App)
    .use(router)
    .use(createVuestic()).mount('#app')
