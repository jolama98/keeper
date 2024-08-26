export class Keep {
  constructor(data) {
    this.id = data.id;
    this.name = data.name;
    this.description = data.description;
    this.img = data.img;
    this.views = data.views;
    this.kept = data.kept;
    this.createdAt = new Date(data.createdAt)
    this.updatedAt = new Date(data.updatedAt)
    this.creatorId = data.creatorId
    this.creator = data.creator;
  }
  get recipeBackgroundImage() {
    return `url(${this.img})`
  }
}



const keep = {
  "name": "Artistic",
  "description": "When you believe, you will succeed. They key is to have every key, the key to open every door. Celebrate success right, the only way, apple. Let me be clear, you have to make it through the jungle to make it to paradise.",
  "img": "https://images.unsplash.com/photo-1524293568345-75d62c3664f7?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=774&h=485&q=60",
  "views": 0,
  "kept": 0,
  "creatorId": "6691cd264de80d398f94368a",
  "creator": {
    "name": "bartdude19@dude.com",
    "picture": "https://s.gravatar.com/avatar/7712820af5b5656a3dde11d4c5d5f5a5?s=480&r=pg&d=https%3A%2F%2Fcdn.auth0.com%2Favatars%2Fba.png",
    "id": "6691cd264de80d398f94368a",
    "createdAt": "2024-08-13T22:03:14",
    "updatedAt": "2024-08-13T22:03:14"
  },
  "id": 1,
  "createdAt": "2024-08-23T20:08:41",
  "updatedAt": "2024-08-23T20:08:41"
}
