```
Entity를 써서 DataSource에 매핑시키고
EF와 DTO를 써서 데이터를 만들면 바로 매핑이 되는 방식으로 사용할 경우

// 아래와 같은 방식으로 데이터를 바인딩시키면 바로 적용 가능
private void LoadData() {
	using (var db = new AppDbContext())
	{
		// DB에서 DTO로 매핑
		var projectDtos = db.Products
		                    .Select(p => new ProjectDTO
							{
								Name = p.Name,
								Quantity = p.Quantity
							})
							.toList();
		// 바인딩
		bindingSource.DataSource = productDtos;
	}
}
```