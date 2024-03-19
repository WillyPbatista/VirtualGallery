import { createApp} from 'vue';
import helloWorld from './helloWorld.vue';
//import { createRouter, createWebHistory } from "vue-router";


const app = createApp({
    components:{
       'hello-world' : helloWorld
    }
});

// Configura Vue Router
/*const router = createRouter({
    history: createWebHistory(),
    routes: [
   
    ]
  });
  app.use(router);

*/

app.mount("#app");

