<script setup>
import { Vault } from '@/models/Vault.js';

// const vaults = computed(() => AppState.vaults)
const props = defineProps({
  vaultProps: { type: Vault, required: true }

})
</script>

<template>

  <router-link :to="{ name: 'VaultDetails' }">
    <div v-if="vaultProps" class="card mb-1">
      <div class=" card-body d-flex flex-column justify-content-end">
        <div class="text-bg rounded-5  d-flex  justify-content-between">

          <p class="card-text text-light textShadow fs-4 m-1">{{ vaultProps.name }}</p>
          <div v-if="vaultProps.isPrivate == true">
            <i class="fs-2 mdi mdi-lock bg-light text-black rounded rounded-top-4 "></i>
          </div>
        </div>
      </div>
    </div>
  </router-link>
</template>

<style lang="scss" scoped>
.card {
  height: 25vh;
  background-image: v-bind('vaultProps.recipeBackgroundImage');
  background-position: center;
  background-size: cover;
}
</style>
