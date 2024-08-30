<script setup>
import { AppState } from '@/AppState.js';
import { Vault } from '@/models/Vault.js';
import { vaultService } from '@/services/VaultService.js';
import Pop from '@/utils/Pop.js';
import { computed } from 'vue';

const account = computed(() => AppState.account)

const props = defineProps({
  vaultProp: { type: Vault, required: true }
})


async function destroyVault() {
  try {
    const choice = await Pop.confirm("are you sure?", 'delete Vault')
    if (choice == false) {
      Pop.toast("action canceled successfully", 'info', 'center')
      return
    }
    await vaultService.destroyVault(props.vaultProp.id)
    Pop.success("Vault Deleted!")
  }
  catch (error) {
    Pop.error(error);
  }
}

function setActiveVault() {
  vaultService.setActiveVault(props.vaultProp.id)
}

</script>

<template>
  <i v-if="account?.id == vaultProp.creatorId" @click="destroyVault()" type="button"
    class="mdi mdi-close-octagon-outline fs-5 text-danger d-flex justify-content-end icon-pos"></i>

  <router-link :to="{ name: 'VaultDetails', params: { vaultId: vaultProp.id } }">
    <div v-if="vaultProp" class="card mb-1">
      <div class=" card-body d-flex flex-column justify-content-end" @click="setActiveVault()">
        <div class="text-bg rounded-5  d-flex  justify-content-between">

          <p class="card-text text-light textShadow fs-4 m-1">{{ vaultProp.name }}</p>
          <div v-if="vaultProp.isPrivate == true">
            <i class="fs-2 mdi mdi-lock bg-light text-black rounded rounded-top-4 "></i>
          </div>
        </div>
      </div>
    </div>
  </router-link>
</template>

<style lang="scss" scoped>
.icon-pos {
  margin: -5%;
}

.textShadow {
  text-shadow: 1px 1px 1px rgb(0, 0, 0);
  font-family: marko-one;

}

.card {
  height: 25vh;
  background-image: v-bind('vaultProp.backgroundImage');
  background-position: center;
  background-size: cover;
}
</style>
