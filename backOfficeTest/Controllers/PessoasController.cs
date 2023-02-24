using BackOffice.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Controllers.Models;

namespace WebAPI.Controllers.backOffice
{
    [ApiController]
    [Route("api/[controller]")]
    public class PessoasController : ControllerBase
    {
        private readonly BackOfficeContext _contexto;

        public PessoasController(BackOfficeContext contexto)
        {
            _contexto = contexto;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pessoa>>> ObterPessoas()
        {
            return await _contexto.Pessoas.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Pessoa>> ObterPessoaPorId(int id)
        {
            var pessoa = await _contexto.Pessoas.FindAsync(id);

            if (pessoa == null)
            {
                return NotFound();
            }

            return pessoa;
        }

        [HttpPost]
        public async Task<ActionResult<Pessoa>> CadastrarPessoa(Pessoa pessoa)
        {
            if (PessoaJaCadastrada(pessoa.Documento))
            {
                return Conflict();
            }

            _contexto.Pessoas.Add(pessoa);
            await _contexto

                 .SaveChangesAsync();

            return CreatedAtAction(nameof(ObterPessoaPorId), new { id = pessoa.Id }, pessoa);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> AtualizarPessoa(int id, Pessoa pessoaAtualizada)
        {
            if (id != pessoaAtualizada.Id)
            {
                return BadRequest();
            }

            var pessoaExistente = await _contexto.Pessoas.FindAsync(id);

            if (pessoaExistente == null)
            {
                return NotFound();
            }

            if (PessoaJaCadastrada(pessoaAtualizada.Documento) && pessoaAtualizada.Id != pessoaExistente.Id)
            {
                return Conflict();
            }

            //pessoaExistente.TipoPessoa = pessoaAtualizada.TipoPessoa;
            pessoaExistente.Documento = pessoaAtualizada.Documento;
            pessoaExistente.Nome = pessoaAtualizada.Nome;
            pessoaExistente.Apelido = pessoaAtualizada.Apelido;
            pessoaExistente.Endereco = pessoaAtualizada.Endereco;

            try
            {
                await _contexto.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException) when (!PessoaExistente(id))
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> ExcluirPessoa(int id)
        {
            var pessoa = await _contexto.Pessoas.FindAsync(id);

            if (pessoa == null)
            {
                return NotFound();
            }

            _contexto.Pessoas.Remove(pessoa);
            await _contexto.SaveChangesAsync();

            return NoContent();
        }

        private bool PessoaExistente(int id)
        {
            return _contexto.Pessoas.Any(e => e.Id == id);
        }

        private bool PessoaJaCadastrada(string documento)
        {
            return _contexto.Pessoas.Any(e => e.Documento == documento);
        }
    }
    }