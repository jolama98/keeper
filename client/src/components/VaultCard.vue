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
  <div class="card">

    <div class="card-img-overlay d-flex flex-column justify-content-between">

      <i v-if="account?.id == vaultProp.creatorId" @click="destroyVault()" type="button"
        class="delete-button  fs-1 text-danger d-flex icon-pos">
        <svg class="delete-svgIcon" viewBox="0 0 448 512">
          <path
            d="M135.2 17.7L128 32H32C14.3 32 0 46.3 0 64S14.3 96 32 96H416c17.7 0 32-14.3 32-32s-14.3-32-32-32H320l-7.2-14.3C307.4 6.8 296.3 0 284.2 0H163.8c-12.1 0-23.2 6.8-28.6 17.7zM416 128H32L53.2 467c1.6 25.3 22.6 45 47.9 45H346.9c25.3 0 46.3-19.7 47.9-45L416 128z">
          </path>
        </svg>
      </i>
      <router-link :to="{ name: 'VaultDetails', params: { vaultId: vaultProp.id } }">
        <div v-if="vaultProp" class=" mb-1">
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

    </div>
  </div>
</template>

<style lang="scss" scoped>
// .icon-pos {
//   margin: -5%;
// }

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


.icon-pos {
  margin: +0.5%;
}

/* From Uiverse.io by aaronross1 */
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
