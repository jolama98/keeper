<script setup>
import { AppState } from '@/AppState.js';
import { Keep } from '@/models/Keep.js';
import { VaultKeepKeep } from '@/models/VaultKeep.js';
import { keepsService } from '@/services/KeepsService.js';
import { vaultKeepService } from '@/services/vaultKeepService.js';
import Pop from '@/utils/Pop.js';
import { computed } from 'vue';


const props = defineProps({
  vaultProp: { type: VaultKeepKeep, required: true }
})
const account = computed(() => AppState.account)

function setActiveKeep(keepId) {
  keepsService.getKeepById(keepId)
}


async function removeKeepFormVault(vaultKeepId) {
  try {
    const wantsToDelete = await Pop.confirm("Are you sure you want to remove this Keep????")
    if (!wantsToDelete) return
    await vaultKeepService.removeKeepFormVault(vaultKeepId)
  }
  catch (error) {
    Pop.error(error);
  }
}
</script>


<template>
  <div v-if="vaultProp" class="mb-1">
    <i type="button" @click="removeKeepFormVault(vaultProp.vaultKeepId)"
      class="mdi mdi-close-octagon-outline fs-5 text-danger d-flex justify-content-end icon-pos"></i>
    <div class="card-body d-flex flex-column justify-content-end" @click="setActiveKeep(vaultProp.id)"
      data-bs-toggle="modal" data-bs-target="#keepModal">
      <div class="text-bg rounded-5  d-flex  justify-content-between">
        <img class="img-fluid card" :src="vaultProp.img" alt="">
        <p class="card-text text-light textShadow fs-4 m-1">{{ vaultProp.name }}</p>

        <RouterLink :to="{ name: 'Profile', params: { profileId: vaultProp.creatorId } }"
          :title="`Go to ${vaultProp.creator.name}'s profile page`">
          <img data-bs-dismiss=" modal" aria-label="Close" class="avatar p-1" :src="vaultProp.creator.picture" alt="">
        </RouterLink>
      </div>
    </div>
  </div>
</template>


<style lang="scss" scoped>
.card {
  height: 25vh;

  background-position: center;
  background-size: cover;
}

.textShadow {
  text-shadow: 1px 1px 1px rgb(0, 0, 0);
  font-family: marko-one;

}

.avatar {
  vertical-align: middle;
  width: 50px;
  height: 50px;
  border-radius: 50%;
}



.icon-pos {
  margin: +5%;
}
</style>
