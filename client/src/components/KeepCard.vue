<script setup>
import { Keep } from '@/models/Keep.js';
import { keepsService } from '../services/KeepsService.js';
import Pop from '@/utils/Pop.js';
import { computed } from 'vue';
import { AppState } from '@/AppState.js';
import { RouterLink } from 'vue-router';


const props = defineProps({
  keepProps: { type: Keep, required: true }
})
const account = computed(() => AppState.account)

async function deleteKeep(keepId) {
  try {
    const choice = await Pop.confirm("are you sure?", 'delete Keep')
    if (choice == false) {
      Pop.toast("action canceled successfully", 'info', 'center')
      return
    }
    await keepsService.destroyKeep(props.keepProps.id)
    Pop.success("Keep Deleted!")
  }
  catch (error) {
    Pop.error(error);
  }
}
function setActiveKeep(keepId) {
  keepsService.getKeepById(keepId)
}
</script>


<template>

  <div v-if="keepProps" class="card mb-1">
    <i v-if="account?.id == keepProps.creator.id" type="button" @click="deleteKeep(keepProps.id)"
      class="mdi mdi-close-octagon-outline fs-5 text-danger d-flex justify-content-end icon-pos"></i>
    <div class="card-body d-flex flex-column justify-content-end" @click="setActiveKeep(keepProps.id)"
      data-bs-toggle="modal" data-bs-target="#keepModal">
      <div class="text-bg rounded-5  d-flex  justify-content-between">
        <p class="card-text text-light textShadow fs-4 m-1">{{ keepProps.name }}</p>

        <RouterLink :to="{ name: 'Profile', params: { profileId: keepProps.creatorId } }"
          :title="`Go to ${keepProps.creator.name}'s profile page`">
          <img data-bs-dismiss=" modal" aria-label="Close" class="avatar p-1" :src="keepProps.creator.picture" alt="">
        </RouterLink>
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

.avatar {
  vertical-align: middle;
  width: 50px;
  height: 50px;
  border-radius: 50%;
}



.icon-pos {
  margin: -5%;
}
</style>
