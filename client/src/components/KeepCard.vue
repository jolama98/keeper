<script setup>
import { Keep } from '@/models/Keep.js';
import { keepsService } from '../services/KeepsService.js';

// async function setActiveRecipe() {
//   recipeService.setActiveRecipe(props.recipeProp)
//   await router.push({ query: { recipeId: `${props.recipeProp.id}` } })
//   logger.log(router.currentRoute)
// }

function setActiveKeep() {
  keepsService.setActiveKeep(props.keepProps)
  console.log(props.keepProps.name);
}

const props = defineProps({
  keepProps: { type: Keep, required: true }
})
</script>


<template>

  <div class="card mb-1" @click="setActiveKeep()" type="button" data-bs-toggle="modal" data-bs-target="#keepModal">
    <div class="card-body d-flex flex-column justify-content-end">
      <div class="text-bg rounded-5 p-1 d-flex align-self-start">
        <p class="card-text text-light textShadow fs-4  m-1">{{ props.keepProps.name }}</p>
      </div>
    </div>
  </div>
</template>

<style lang="scss" scoped>
.card {
  height: 25vh;
  background-image: v-bind('keepProps.recipeBackgroundImage');
  background-position: center;
  background-size: cover;
}

.textShadow {
  text-shadow: 1px 1px 1px rgb(0, 0, 0);
  font-family: marko-one;

}
</style>
