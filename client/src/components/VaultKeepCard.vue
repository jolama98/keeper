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
  <div v-if="vaultProp" class="card">
    <img class="img-fluid" :src="vaultProp.img" alt="">
    <div class="card-img-overlay d-flex flex-column justify-content-between">

      <i v-if="account?.id == vaultProp.creator.id" type="button" @click="removeKeepFormVault(vaultProp.vaultKeepId)"
        class=" delete-button mdi mdi-close-octagon-outline fs-1 text-danger d-flex icon-pos">
        <svg class="delete-svgIcon" viewBox="0 0 448 512">
          <path
            d="M135.2 17.7L128 32H32C14.3 32 0 46.3 0 64S14.3 96 32 96H416c17.7 0 32-14.3 32-32s-14.3-32-32-32H320l-7.2-14.3C307.4 6.8 296.3 0 284.2 0H163.8c-12.1 0-23.2 6.8-28.6 17.7zM416 128H32L53.2 467c1.6 25.3 22.6 45 47.9 45H346.9c25.3 0 46.3-19.7 47.9-45L416 128z">
          </path>
        </svg>
      </i>

      <div class="card-body d-flex flex-column justify-content-end" @click="setActiveKeep(vaultProp.id)"
        data-bs-toggle="modal" data-bs-target="#keepModal">
        <div class="text-bg rounded-5  d-flex  justify-content-between">
          <p class="card-text text-light textShadow fs-4 m-1">{{ vaultProp.name }}</p>

          <!-- <RouterLink :to="{ name: 'Profile', params: { profileId: vaultProp.creatorId } }"
    :title="`Go to ${vaultProp.creator.name}'s profile page`">
    <img data-bs-dismiss=" modal" aria-label="Close" class="avatar p-1" :src="vaultProp.creator.picture" alt="">
  </RouterLink> -->
        </div>
      </div>
    </div>
  </div>
</template>


<style lang="scss" scoped>
.card {}

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
  margin: +1%;
}



.delete-button {
  width: 40px;
  height: 40px;
  border-radius: 50%;
  background-color: rgb(255, 255, 255);
  border: none;
  font-weight: 600;
  display: flex;
  align-items: center;
  justify-content: center;
  box-shadow: 0px 0px 20px rgba(255, 255, 255, 0.066);
  cursor: pointer;
  transition-duration: 0.3s;
  overflow: hidden;
  position: relative;
}

.delete-svgIcon {
  width: 15px;
  transition-duration: 0.3s;
}

.delete-svgIcon path {
  fill: rgb(0, 0, 0);
}

.delete-button:hover {
  width: 90px;
  border-radius: 50px;
  transition-duration: 0.3s;
  background-color: rgb(255, 69, 69);
  align-items: center;
}

.delete-button:hover .delete-svgIcon {
  width: 20px;
  transition-duration: 0.3s;
  transform: translateY(60%);
  -webkit-transform: rotate(360deg);
  -moz-transform: rotate(360deg);
  -o-transform: rotate(360deg);
  -ms-transform: rotate(360deg);
  transform: rotate(360deg);
}

.delete-button::before {
  display: none;
  content: "Delete";
  color: white;
  transition-duration: 0.3s;
  font-size: 2px;
}

.delete-button:hover::before {
  display: block;
  padding-right: 10px;
  font-size: 13px;
  opacity: 1;
  transform: translateY(0px);
  transition-duration: 0.3s;
}
</style>
