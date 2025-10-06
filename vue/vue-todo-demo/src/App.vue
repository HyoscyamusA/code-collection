<script setup>
import { ref } from 'vue'

// 定义变量数据
const newTask = ref('')  // 当前输入框的内容
const tasks = ref([])   // 所有任务的数组

// 添加任务函数
const addTask = () => {
  if (newTask.value.trim() === '') return //newTask.value,获取用户在输入框中输入的内容,trim去掉字符串首尾的空格,然后判断输入是否为空，如果是空字符串直接return，防止输入空任务
  tasks.value.push({
    id: Date.now(),//生成一个唯一的任务 ID用它来区分任务，方便删除。
    text: newTask.value,//任务的文字内容，就是用户输入的内容。
    done: false //表示任务是否完成。初始为 false（未完成）。
  })
  newTask.value = ''//将输入框初始化
}

// 删除任务
const deleteTask = (id) => {
  tasks.value = tasks.value.filter(task => task.id !== id)
}

// 切换完成状态
const toggleTask = (task) => {
  task.done = !task.done
}
</script>

<template>
  <div class="container">
    <h1>Vue 3 TodoList</h1>

    <!-- 输入框和按钮 -->
    <input v-model="newTask" placeholder="输入新任务..." />
    <button @click="addTask">添加</button>

    <!-- 任务列表 -->
    <ul>
      <li v-for="task in tasks" :key="task.id">
        <input type="checkbox" v-model="task.done" @change="toggleTask(task)" />
        <span :style="{ textDecoration: task.done ? 'line-through' : 'none' }">
          {{ task.text }}
        </span>
        <button @click="deleteTask(task.id)">删除</button>
      </li>
    </ul>
  </div>
</template>

<style>
.container {
  max-width: 400px;
  margin: 0 auto;
  font-family: sans-serif;
}
input {
  padding: 5px;
  margin-right: 5px;
}
button {
  margin-left: 5px;
}
</style>

