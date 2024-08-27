<script setup>
import { Keep } from '@/models/Keep.js';
import { keepsService } from '../services/KeepsService.js';
import Pop from '@/utils/Pop.js';
import { computed } from 'vue';
import { AppState } from '@/AppState.js';

// async function deleteComment(commentId) {
//   try {
//     const choice = await Pop.confirm("are you sure?", 'delete comment')
//     if (choice == false) {
//       Pop.toast("action canceled successfully", 'info', 'center')
//       return
//     }


//     await commentService.deleteComment(commentId)
//     Pop.success("Comment Deleted!")

//   } catch (error) {
//     logger.error(error)
//   }
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
function setActiveKeep() {
  keepsService.setActiveKeep(props.keepProps)
}


</script>


<template>

  <div class="card mb-1">
    <i v-if="account?.id == props.keepProps.creator.id" type="button" @click="deleteKeep(props.keepProps.id)"
      class="mdi mdi-close-octagon-outline fs-5 text-danger d-flex justify-content-end icon-pos"></i>
    <div class="card-body d-flex flex-column justify-content-end" @click="setActiveKeep()" data-bs-toggle="modal"
      data-bs-target="#keepModal">
      <div class="text-bg rounded-5  d-flex  justify-content-between">
        <p class="card-text text-light textShadow fs-4 m-1">{{ props.keepProps.name }}</p>
        <router-link :to="{ name: 'Profile' }">
          <img data-bs-dismiss="modal" aria-label="Close" class="avatar p-1" :src="props.keepProps.creator.picture"
            alt="">
        </router-link>
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
