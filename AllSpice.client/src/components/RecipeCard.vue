<template>
  <div @click="goTo('Recipe')">
    <div class="p-2">
      <h3 class="text-success">{{ recipe.title }}</h3>
      <h6 class="text-dark">{{ recipe.subTitle }}</h6>
    </div>
    <img class="img-fluid" :src="recipe.picture" alt="" />
  </div>
</template>

<script>
import { useRouter } from "vue-router";
export default {
  props: {
    recipe: {
      type: Object,
      required: true
    }
  },
  setup(props) {
    const router = useRouter();
    return {
      goTo(page) {
        router.push({
          name: page,
          params: { id: props.recipe.id }
        });
      }
    }
  }
}
</script>

<style>
</style>