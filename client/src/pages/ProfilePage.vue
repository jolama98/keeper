<script setup>
import { vaultService } from '@/services/VaultService.js';
import { AppState } from '../AppState.js';
import KeepCard from '../components/KeepCard.vue';
import { keepsService } from '../services/KeepsService.js';
import Pop from '../utils/Pop.js';
import { computed, onMounted } from 'vue';
import { useRoute } from 'vue-router';
import VaultCard from '@/components/VaultCard.vue';
import CreateKeepForm from '../components/CreateKeepFrom.vue';

const route = useRoute()

const account = computed(() => AppState.account.id)
const keeps = computed(() => AppState.keeps)
const accountVaults = computed(() => AppState.accountVaults)

onMounted(() => {
  gatAllKeeps()
  // getAllVaults()
  // getVaultsById()
})
// async function getVaultsById() {
//   try {

//     await vaultService.getVaultsById()
//   }
//   catch (error) {
//     Pop.error(error);
//   }
// }

// async function getAllVaults() {
//   try {
//     await vaultService.getAllVaults()
//   }
//   catch (error) {
//     Pop.error(error);
//   }
// }


async function gatAllKeeps() {
  try {
    await keepsService.getAllKeeps()
  }
  catch (error) {
    Pop.error(error);
  }
}
</script>


<template>
  <div class="container">
    <p class="fs-1 fw-bolder">Vaults</p>
    <div class="row">
      <div v-for="accountVault in accountVaults" :key="accountVault.id" class="col-md-3 col-6">
        <VaultCard :vault="accountVault.vault" />
      </div>
    </div>
    <p class="fs-1 fw-bolder">Keeps</p>
    <!-- :class="account?.id == carProp.creatorId ? 'justify-content-between' :
          'justify-content-end'"> -->
    <div class="row">
      <div v-for="keep in keeps" :key="keep.id" class="img-card col-md-3 col-6 pt-2 ">
        <KeepCard :keepProps="keep" />
      </div>
    </div>
  </div>
  <CreateKeepForm />
</template>


<style lang="scss" scoped></style>
