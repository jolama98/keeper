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

